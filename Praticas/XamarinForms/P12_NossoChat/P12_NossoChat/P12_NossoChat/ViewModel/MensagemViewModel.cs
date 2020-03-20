using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using P12_NossoChat.Model;
using P12_NossoChat.Service;
using P12_NossoChat.Utils;
using Xamarin.Forms;

namespace P12_NossoChat.ViewModel
{
    public class MensagemViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Chat CurrentChat;
        private StackLayout stack;
        public Command BtnSendCommand { get; set; }
        public Command AtualizarCommand { get; set; }
        public MensagemViewModel(Chat c, StackLayout MensagensStack)
        {
            this.CurrentChat = c;
            this.stack = MensagensStack;
            this.Atualizar();
            this.BtnSendCommand = new Command(BtnSendAction);
            this.AtualizarCommand = new Command(Atualizar);

            Device.StartTimer(TimeSpan.FromSeconds(1.2), () => {
                this.Atualizar();
                return true;
            });
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
            this.Mensagens = WebService.GetMensagens(CurrentChat);
        }

        private List<Mensagem> _mensagens;
        public List<Mensagem> Mensagens {
            get {
                return _mensagens;
            }
            set {
            Console.WriteLine("Eu tenho certeza absoluta que passei por aqui!!!!");
                _mensagens = value;
                OnPropertyChanged("Mensagens");
                if(value != null) {
                    this.LoadMsgOnScreen();
                }
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

        private void LoadMsgOnScreen()
        {
            var userLogged = UserUtils.UserLogged;
            stack.Children.Clear();
            foreach(var msg in Mensagens) {
                if (userLogged.id == msg.id_usuario) {
                    stack.Children.Add(MakeUserMsgLayout(msg));
                }
                else {
                    stack.Children.Add(MakeOthersMsgLayout(msg));
                }
            }
        }


        private Xamarin.Forms.View MakeUserMsgLayout(Mensagem msg)
        {
            var layout = new StackLayout() {
                Padding = 5,
                BackgroundColor = MainColor,
                HorizontalOptions = LayoutOptions.End
            };
            layout.Children.Add(new Label() {
                TextColor = SecondaryColor,
                Text = msg.mensagem
            });
            return layout;
        }

        private Xamarin.Forms.View MakeOthersMsgLayout(Mensagem msg)
        {
            var frame = new Frame() {
                BorderColor = MainColor,
                CornerRadius = 0,
                HorizontalOptions = LayoutOptions.Start,
                Content = new StackLayout()
            };

            var stack = frame.Content as StackLayout;

            stack.Children.Add(new Label() {
                Text = msg.usuario.nome,
                FontSize = 10,
                TextColor = MainColor
            });

            stack.Children.Add(new Label() {
                Text = msg.mensagem,
                TextColor = MainColor
            });

            return frame;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
