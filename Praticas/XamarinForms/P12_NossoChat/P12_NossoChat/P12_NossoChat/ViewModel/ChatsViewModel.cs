using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using P12_NossoChat.Model;
using P12_NossoChat.Service;
using Xamarin.Forms;

namespace P12_NossoChat.ViewModel
{
    public class ChatsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private List<Chat> _chats;
        public List<Chat> Chats {
            get {
                return _chats;
            }
            set {
                _chats = value;
                OnPropertyChanged("Chats");
            }
        }

        private Chat _selectedchat;
        public Chat SelectedChat {
            get {
                return _selectedchat;
            }
            set {
                _selectedchat = value;
                OnPropertyChanged("SelectedChat");
                this.ToMessagemPage(_selectedchat);
            }
        }
        private void ToMessagemPage(Chat c)
        {
            if(App.Current.MainPage is NavigationPage np && c != null) {
                SelectedChat = null;
                np.Navigation.PushAsync(new View.Mensagem(c));
            }
        }

        public Command AddChatCommand { get; set; }
        public Command OrdernarChatsCommand { get; set; }
        public Command AtualizarChatsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ChatsViewModel()
        {
            this.Chats = WebService.GetChats();
            this.AddChatCommand = new Command(Adicionar);
            this.OrdernarChatsCommand = new Command(Ordernar);
            this.AtualizarChatsCommand = new Command(Atualizar);
        }

        private void Adicionar()
        {
            if(App.Current.MainPage is NavigationPage np) {
                np.Navigation.PushAsync(new View.CadastrarChat());
            }
        }

        private void Ordernar()
        {
            this.Chats = Chats.OrderBy(c => c.nome).ToList();
        }

        private void Atualizar()
        {
            this.Chats = WebService.GetChats();
        }

        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
