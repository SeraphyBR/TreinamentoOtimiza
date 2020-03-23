using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P12_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        public PaginaInicial()
        {
            InitializeComponent();
            BindingContext = new ViewModel.PaginaInicialViewModel();
        }
    }
}