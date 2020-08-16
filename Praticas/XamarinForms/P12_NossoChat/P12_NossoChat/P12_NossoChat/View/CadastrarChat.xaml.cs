using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P12_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarChat : ContentPage
    {
        public CadastrarChat()
        {
            InitializeComponent();
            BindingContext = new ViewModel.CadastrarChatViewModel();
        }
    }
}