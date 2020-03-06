using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        public PickerPage()
        {
            InitializeComponent();
        }

        private void HandleIndexChanged(object sender, EventArgs args)
        {
            Picker p = (Picker)sender;
            LabelSelectedItem.Text = $"{p.SelectedItem.ToString()} - {p.SelectedIndex}";
        }
    }
}