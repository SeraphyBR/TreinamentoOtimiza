using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarPage : ContentPage
    {
        private List<String> lista;

        public SearchBarPage()
        {
            InitializeComponent();

            this.lista = new List<string> {
                "Amazon",
                "Apple",
                "Google",
                "IBM",
                "Red Hat",
                "Canonical",
                "Microsoft",
                "Uber",
                "Netflix"
            };

            Preencher(lista);
        }

        private void Preencher(List<String> lista)
        {
            ListResult.Children.Clear();
            foreach (var item in lista) {
                ListResult.Children.Add(new Label { Text = item });
            }
        }

        private void Pesquisar(SearchBar search, EventArgs args)
        {
            string word = search.Text.ToLower();
            var result = lista.Where(s => s.ToLower().Contains(word)).ToList<String>();
            Preencher(result);
        }

        private void Pesquisar(object sender, TextChangedEventArgs args)
        {
            string word = args.NewTextValue.ToLower();
            var result = lista.Where(s => s.ToLower().Contains(word)).ToList<String>();
            Preencher(result);
        }
    }
}