using P12_NossoChat.Model;
using P12_NossoChat.Service;
using P12_NossoChat.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace P12_NossoChat.ViewModel
{
    public class MensagemViewModel : Colors, INotifyPropertyChanged
    {
        private Chat CurrentChat;
        public Command BtnSendCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<Mensagem> _mensagens;

        public List<Mensagem> Mensagens {
            get {
                return _mensagens;
            }
            set {
                _mensagens = value;
                OnPropertyChanged("Mensagens");
            }
        }

        private string _userMsg;

        public string UserMsg {
            get {
                return _userMsg;
            }
            set {
                _userMsg = value;
                OnPropertyChanged("UserMsg");
            }
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

        public MensagemViewModel(Chat c)
        {
            this.CurrentChat = c;
            this.Atualizar();
            this.BtnSendCommand = new Command(BtnSendAction);
            this.AtualizarCommand = new Command(Atualizar);

            /*Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                this.Atualizar();
                return true;
            });*/
        }

        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void BtnSendAction()
        {
            var msg = new Mensagem() {
                id_usuario = UserUtils.UserLogged.id,
                mensagem = UserMsg,
                id_chat = CurrentChat.id
            };
            WebService.SendMensagem(msg);
            this.Atualizar();
            this.UserMsg = string.Empty;
        }

        private void Atualizar()
        {
            Task.Run(async () => {
                this.Carregando = true;
                this.Mensagens = await WebService.GetMensagens(CurrentChat);
                this.Carregando = false;
            });
        }
    }
}