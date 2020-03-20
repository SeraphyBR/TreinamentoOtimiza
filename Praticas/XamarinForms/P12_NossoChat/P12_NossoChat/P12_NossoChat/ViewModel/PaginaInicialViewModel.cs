﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using P12_NossoChat.Model;
using P12_NossoChat.Service;
using P12_NossoChat.Utils;
using Newtonsoft.Json;

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
                PropertyChanged(this, new PropertyChangedEventArgs("Nome"));
            }
        }
        public string Senha {
            get {
                return _senha;
            }
            set {
                _senha = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Senha"));
            }
        }

        public string Alerta {
            get {
                return _alerta;
            }
            set {
                _alerta = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Alerta"));
            }
        }
        public bool Carregando {
            get {
                return _carregando;
            }
            set {
                _carregando = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Carregando"));
            }
        }

        public Command EntrarCommand { get; set; }
        
        public PaginaInicialViewModel()
        {
            EntrarCommand = new Command(EntrarAction);
        }

        private async void EntrarAction()
        {
            var user = new Usuario() {
                nome = Nome,
                password = Senha
            };
            this.Carregando = true;
            var userLogged = await WebService.GetUsuario(user);
            this.Carregando = false;
            if(userLogged is null) {
                Alerta = "Senha incorreta.";
            }
            else {
                UserUtils.UserLogged = userLogged;
                App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor = MainColor, BarTextColor = SecondaryColor};
            }
        }
    }
}
