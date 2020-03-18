using P11_Mimica.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P11_Mimica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jogo : ContentPage
    {
        public Jogo(Grupo g)
        {
            InitializeComponent();
            BindingContext = new ViewModel.JogoViewModel(g);
        }
    }
}