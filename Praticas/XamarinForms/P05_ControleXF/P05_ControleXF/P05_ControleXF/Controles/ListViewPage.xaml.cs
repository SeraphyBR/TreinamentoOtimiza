using P05_ControleXF.Modelos;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            var lista = new List<Pessoa> {
                new Pessoa { Nome = "Luiz", Idade = "20"},
                new Pessoa { Nome = "Carlos", Idade = "19"},
                new Pessoa { Nome = "Ruan", Idade = "18"},
                new Pessoa { Nome = "Matheus", Idade = "17"},
                new Pessoa { Nome = "José", Idade = "61"}
            };
            ListPessoas.ItemsSource = lista;
        }
    }
}