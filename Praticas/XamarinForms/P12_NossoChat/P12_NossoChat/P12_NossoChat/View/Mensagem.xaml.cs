using P12_NossoChat.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P12_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mensagem : ContentPage
    {
        public Mensagem(Chat c)
        {
            InitializeComponent();
            BindingContext = new ViewModel.MensagemViewModel(c);
        }
    }
}