using P11_Mimica.Model;
using System.ComponentModel;
using Xamarin.Forms;

namespace P11_Mimica.ViewModel
{
    public class ResultadoViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command JogarNovamente { get; set; }

        public ResultadoViewModel()
        {
            this.Jogo = Storage.Storage.Jogo;
            this.JogarNovamente = new Command(JogarNovamenteAction);
        }

        private void JogarNovamenteAction()
        {
            App.Current.MainPage = new View.Inicio();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
        }
    }
}