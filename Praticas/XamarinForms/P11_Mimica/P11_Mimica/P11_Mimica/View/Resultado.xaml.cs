using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P11_Mimica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resultado : ContentPage
    {
        public Resultado()
        {
            InitializeComponent();
            BindingContext = new ViewModel.ResultadoViewModel();
        }
    }
}