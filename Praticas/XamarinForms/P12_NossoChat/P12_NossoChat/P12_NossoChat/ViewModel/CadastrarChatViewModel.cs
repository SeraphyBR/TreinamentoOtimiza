using P12_NossoChat.Model;
using P12_NossoChat.Service;
using P12_NossoChat.Utils;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace P12_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : Colors, INotifyPropertyChanged
    {
        private string _alerta { get; set; }
        public string nomeChat { get; set; }

        public Command CadastrarCommand { get; set; }

        public string Alerta {
            get {
                return _alerta;
            }
            set {
                _alerta = value;
                OnPropertyChanged("Alerta");
            }
        }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(CadastrarBtn);
        }

        private void CadastrarBtn()
        {
            bool cadastrou = Task.Run(() => this.Cadastrar()).GetAwaiter().GetResult();
            if (cadastrou) {
                if (App.Current.MainPage is NavigationPage current) {
                    current.PopAsync();
                }
            }
        }

        private async Task<bool> Cadastrar()
        {
            bool cadastrou = false;
            var chat = new Chat() { nome = nomeChat };
            this.Carregando = true;
            if (await WebService.InsertChat(chat)) {
                if (App.Current.MainPage is NavigationPage current) {
                    var chats = current.RootPage.BindingContext as ChatsViewModel;
                    if (chats.AtualizarChatsCommand.CanExecute(null)) {
                        chats.AtualizarChatsCommand.Execute(null);
                    }
                    cadastrou = true;
                }
            }
            else {
                Alerta = "Ocorreu um erro no cadastro!";
                this.Carregando = false;
            }
            return cadastrou;
        }

        private bool _carregando;

        public bool Carregando {
            get {
                return _carregando;
            }
            set {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}