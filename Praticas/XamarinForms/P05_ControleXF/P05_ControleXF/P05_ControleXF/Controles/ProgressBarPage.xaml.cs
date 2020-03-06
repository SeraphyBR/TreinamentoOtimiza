using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarPage : ContentPage
    {
        public ProgressBarPage()
        {
            InitializeComponent();
        }

        private void Modificar(object sender, EventArgs args)
        {
            PBar1.Progress = 1;
            PBar2.ProgressTo(1, 5000, Easing.Linear);
            PBar3.ProgressTo(1, 5000, Easing.SpringIn);
        }
    }
}