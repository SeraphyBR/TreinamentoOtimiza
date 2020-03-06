using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryEditorPage : ContentPage
    {
        public EntryEditorPage()
        {
            InitializeComponent();

            EntryIdade.TextChanged += delegate (object sender, TextChangedEventArgs args) {
                Label.Text = args.NewTextValue;
            };

            EditorComentario.Completed += delegate (object sender, EventArgs args) {
                LabelQuantChar.Text = EditorComentario.Text.Length.ToString();
            };
        }
    }
}