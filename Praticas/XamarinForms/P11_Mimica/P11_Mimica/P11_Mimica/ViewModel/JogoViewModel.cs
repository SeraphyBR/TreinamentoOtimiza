using P11_Mimica.Model;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace P11_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        public Grupo Grupo { get; set; }
        public string NomeGrupo { get; set; }
        public string NumeroGrupo { get; set; }

        private byte _Pontuacao;
        private string _Palavra;
        private string _TextoTempo;
        private bool _IsVisibleContainerContagem;
        private bool _IsVisibleBtnIniciar;
        private bool _IsVisibleBtnMostrar;

        public byte PalavraPontuacao {
            get {
                return _Pontuacao;
            }
            set {
                _Pontuacao = value;
                OnPropertyChanged("PalavraPontuacao");
            }
        }

        public string Palavra {
            get {
                return _Palavra;
            }
            set {
                _Palavra = value;
                OnPropertyChanged("Palavra");
            }
        }

        public string TextoTempo {
            get {
                return _TextoTempo;
            }
            set {
                _TextoTempo = value;
                OnPropertyChanged("TextoTempo");
            }
        }

        public bool IsVisibleContainerContagem {
            get {
                return _IsVisibleContainerContagem;
            }
            set {
                _IsVisibleContainerContagem = value;
                OnPropertyChanged("IsVisibleContainerContagem");
            }
        }

        public bool IsVisibleBtnIniciar {
            get {
                return _IsVisibleBtnIniciar;
            }
            set {
                _IsVisibleBtnIniciar = value;
                OnPropertyChanged("IsVisibleBtnIniciar");
            }
        }

        public bool IsVisibleBtnMostrar {
            get {
                return _IsVisibleBtnMostrar;
            }
            set {
                _IsVisibleBtnMostrar = value;
                OnPropertyChanged("IsVisibleBtnMostrar");
            }
        }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel(Grupo g)
        {
            this.Grupo = g;
            this.NomeGrupo = g.Nome;
            if (Grupo.Equals(Storage.Storage.Jogo.G1)) {
                this.NumeroGrupo = "Grupo 1";
            }
            else {
                this.NumeroGrupo = "Grupo 2";
            }
            this.IsVisibleContainerContagem = false;
            this.IsVisibleBtnIniciar = false;
            this.IsVisibleBtnMostrar = true;

            this.Palavra = "********";

            this.MostrarPalavra = new Command(MostrarPalavraCommand);
            this.Acertou = new Command(AcertouCommand);
            this.Errou = new Command(ErrouCommand);
            this.Iniciar = new Command(IniciarCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
        }

        private async void MostrarPalavraCommand()
        {
            Random rd = new Random();
            int idx;
            string palavra = "";
            switch (Storage.Storage.Jogo.NivelNum) {
                case 0: //Aleatorio
                    int niv = rd.Next(0, Storage.Storage.Palavras.Length);
                    idx = rd.Next(0, Storage.Storage.Palavras[niv].Length);
                    palavra = Storage.Storage.Palavras[niv][idx];
                    this.PalavraPontuacao = (byte)(1 + niv * 2);
                    break;

                case 1: //Fácil
                    idx = rd.Next(0, Storage.Storage.Palavras[0].Length);
                    palavra = Storage.Storage.Palavras[0][idx];
                    this.PalavraPontuacao = 1;
                    break;

                case 2: //Médio
                    idx = rd.Next(0, Storage.Storage.Palavras[1].Length);
                    palavra = Storage.Storage.Palavras[1][idx];
                    this.PalavraPontuacao = 3;
                    break;

                case 3: //Dificil
                    idx = rd.Next(0, Storage.Storage.Palavras[2].Length);
                    palavra = Storage.Storage.Palavras[2][idx];
                    this.PalavraPontuacao = 5;
                    break;
            }

            this.IsVisibleBtnMostrar = false;
            var hidden = new StringBuilder();
            for (int i = 0; i < palavra.Length; i++) {
                hidden.Append('*');
            }
            this.Palavra = hidden.ToString();
            for (int i = 0; i < palavra.Length; i++) {
                Palavra = Palavra.Remove(i, 1);
                Palavra = Palavra.Insert(i, palavra[i].ToString());
                await Task.Delay(350);
            }

            this.IsVisibleBtnIniciar = true;
            this.PropertyChanged(this, new PropertyChangedEventArgs("Palavra"));
        }

        private void IniciarCommand()
        {
            IsVisibleBtnIniciar = false;
            IsVisibleContainerContagem = true;

            int t = Storage.Storage.Jogo.TempoPalavra;
            TextoTempo = t--.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TextoTempo = t--.ToString();
                if (t < 0) {
                    TextoTempo = "Esgotou o tempo";
                    return false;
                }
                return true;
            });
        }

        private void AcertouCommand()
        {
            Grupo.Pontos += PalavraPontuacao;
            ProximoGrupo();
        }

        private void ErrouCommand()
        {
            ProximoGrupo();
        }

        private void ProximoGrupo()
        {
            Grupo nextg;
            if (Storage.Storage.Jogo.G1 == Grupo) {
                nextg = Storage.Storage.Jogo.G2;
            }
            else {
                nextg = Storage.Storage.Jogo.G1;
                Storage.Storage.RodadaAtual++;
            }
            if (Storage.Storage.RodadaAtual > Storage.Storage.Jogo.Rodadas) {
                App.Current.MainPage = new View.Resultado();
            }
            else {
                App.Current.MainPage = new View.Jogo(nextg);
            }
        }
    }
}