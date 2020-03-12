using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P08_EstilosXF.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicStylePage : ContentPage
    {
        public DynamicStylePage()
        {
            InitializeComponent();
        }

        private void ChangeColor(object sender, EventArgs args)
        {
            this.Resources["LblColor"] = Color.DarkGreen;
            this.Resources["StyleLabel1"] = this.Resources["StyleLabel2"];
        }
    }
}