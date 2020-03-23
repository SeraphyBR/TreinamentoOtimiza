using P12_NossoChat.Model;
using P12_NossoChat.Service;
using P12_NossoChat.Utils;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace P12_NossoChat.ViewModel
{
    public class PaginaInicialViewModel : Colors, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nome;
        private string _senha;
        private string _alerta;
        private bool _carregando;

        public string Nome {
            get {
                return _nome;
            }
            set {
                _nome = value;
                OnPropertyChanged("Nome");
            }
        }

        public string Senha {
            get {
                return _senha;
            }
            set {
                _senha = value;
                OnPropertyChanged("Senha");
            }
        }

        public string Alerta {
            get {
                return _alerta;
            }
            set {
                _alerta = value;
                OnPropertyChanged("Alerta");
            }
        }

        public bool Carregando {
            get {
                return _carregando;
            }
            set {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public Command EntrarCommand { get; set; }

        public PaginaInicialViewModel()
        {
            EntrarCommand = new Command(EntrarAction);
        }

        private async void EntrarAction()
        {
            try {
                var user = new Usuario() {
                    nome = Nome,
                    password = Senha
                };
                this.Carregando = true;
                var userLogged = await WebService.GetUsuario(user);
                this.Carregando = false;
                if (userLogged is null) {
                    Alerta = "Senha incorreta.";
                }
                else {
                    UserUtils.UserLogged = userLogged;
                    App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor = MainColor, BarTextColor = SecondaryColor };
                }
            }
            catch (Exception e) {
                this.Alerta = "Ocorreu um problema no processamento! Tente novamente";
            }
            finally {
                this.Carregando = false;
            }
        }
    }
}