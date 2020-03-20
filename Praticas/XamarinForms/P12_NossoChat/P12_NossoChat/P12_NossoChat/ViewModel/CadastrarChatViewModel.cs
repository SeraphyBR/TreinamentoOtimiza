using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using P12_NossoChat.Model;
using P12_NossoChat.Service;
using System.ComponentModel;

namespace P12_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : BaseViewModel, INotifyPropertyChanged
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
            CadastrarCommand = new Command(Cadastrar);
        }

        private void Cadastrar()
        {
            var chat = new Chat() { nome = nomeChat };
            if (WebService.InsertChat(chat)) {
                if(App.Current.MainPage is NavigationPage np) {
                    np.Navigation.PopAsync();
                    var nav = App.Current.MainPage as NavigationPage;
                    var chats = nav.RootPage.BindingContext as ChatsViewModel;
                    if (chats.AtualizarChatsCommand.CanExecute(null)) {
                        chats.AtualizarChatsCommand.Execute(null);
                    }
                }
            }
            else {
                Alerta = "Ocorreu um erro no cadastro!";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
