using P10_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaVaga : ContentPage
    {
        private List<Vaga> Lista { get; set; }

        public ConsultaVaga()
        {
            InitializeComponent();
            Lista = App.DBVagas.Consultar();
            ListaVagas.ItemsSource = Lista;
            LabelCount.Text = $"{Lista.Count} vagas encontradas";
        }

        public void HandleClickedEvent(object sender, EventArgs args)
        {
            if (sender is Button bt) {
                if (bt.Equals(ButtonCadastraVaga)) {
                    Navigation.PushAsync(new CadastroVagas());
                }
                if (bt.Equals(ButtonMinhasVagas)) {
                    Navigation.PushAsync(new VagasCadastradas());
                }
            }
        }

        public void SearchVaga(object sender, TextChangedEventArgs args)
        {
            var text = args.NewTextValue;
            ListaVagas.ItemsSource = this.Lista.Where(v => v.Nome.Contains(text));
        }

        public void ShowDetalhes(object sender, EventArgs args)
        {
            if (sender is Label l) {
                if (l.GestureRecognizers[0] is TapGestureRecognizer tap) {
                    if (tap.CommandParameter is Vaga v) {
                        Navigation.PushAsync(new DetalheVaga(v));
                    }
                }
            }
        }
    }
}