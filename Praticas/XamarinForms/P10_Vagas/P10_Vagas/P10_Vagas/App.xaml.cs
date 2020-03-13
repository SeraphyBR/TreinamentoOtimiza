﻿using P10_Vagas.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace P10_Vagas
{
    public partial class App : Application
    {
        public static Database DBVagas { get; set; }

        public App()
        {
            InitializeComponent();
            DBVagas = new Database("vagas");
            MainPage = new NavigationPage(new Paginas.ConsultaVaga());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}