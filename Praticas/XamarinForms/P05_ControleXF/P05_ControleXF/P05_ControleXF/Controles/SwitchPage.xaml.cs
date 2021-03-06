﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchPage : ContentPage
    {
        public SwitchPage()
        {
            InitializeComponent();
        }

        private void HandleToggledEvent(object sender, ToggledEventArgs args)
        {
            LabelSwitch.Text = $"{DateTime.Now.ToString("hh:mm")} - {args.Value}";
        }
    }
}