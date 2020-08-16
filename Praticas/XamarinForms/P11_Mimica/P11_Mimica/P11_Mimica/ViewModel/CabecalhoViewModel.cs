using Xamarin.Forms;

namespace P11_Mimica.ViewModel
{
    public class CabecalhoViewModel
    {
        public Command Sair { get; set; }

        public CabecalhoViewModel()
        {
            this.Sair = new Command(SairAction);
        }

        private void SairAction()
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}