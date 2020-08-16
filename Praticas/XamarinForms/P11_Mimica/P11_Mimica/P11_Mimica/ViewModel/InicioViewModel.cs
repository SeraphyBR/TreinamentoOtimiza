using P11_Mimica.Model;
using System.ComponentModel;
using Xamarin.Forms;

namespace P11_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        private string _MsgValidacao;
        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }

        public string MsgValidacao {
            get {
                return _MsgValidacao;
            }
            set {
                _MsgValidacao = value;
                OnPropertyChanged("MsgValidacao");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo {
                G1 = new Grupo(),
                G2 = new Grupo(),
                TempoPalavra = 120,
                Rodadas = 7
            };
        }

        private void IniciarJogo()
        {
            string msgvalidacao = "";
            if (Jogo.TempoPalavra < 10) {
                msgvalidacao += "O tempo mínimo para o tempo da palavra é 10 segundos.\n";
            }
            if (Jogo.Rodadas < 1) {
                msgvalidacao += "O valor mínimo para a rodada é 1.\n";
            }
            if (msgvalidacao.Length > 0) {
                this.MsgValidacao = msgvalidacao;
            }
            else {
                Storage.Storage.Jogo = this.Jogo;
                Storage.Storage.RodadaAtual = 1;
                App.Current.MainPage = new View.Jogo(Jogo.G1);
            }
        }

        private void OnPropertyChanged(string NameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
        }
    }
}