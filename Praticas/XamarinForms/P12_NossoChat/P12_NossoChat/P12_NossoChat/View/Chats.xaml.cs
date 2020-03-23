using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P12_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chats : ContentPage
    {
        public Chats()
        {
            InitializeComponent();
            BindingContext = new ViewModel.ChatsViewModel();
        }
    }
}