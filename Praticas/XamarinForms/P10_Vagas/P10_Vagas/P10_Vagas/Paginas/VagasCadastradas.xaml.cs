using P10_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VagasCadastradas : ContentPage
    {
        private List<Vaga> Lista { get; set; }

        public VagasCadastradas()
        {
            InitializeComponent();
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            Lista = App.DBVagas.Consultar();
            ListVagas.ItemsSource = Lista;
            LabelCount.Text = $"{Lista.Count} Vagas cadastradas";
        }

        public void EditarVaga(object sender, EventArgs args)
        {
            if (sender is Label l) {
                if (l.GestureRecognizers[0] is TapGestureRecognizer tap) {
                    if (tap.CommandParameter is Vaga v) {
                        Navigation.PushAsync(new Edicao(v));
                    }
                }
            }
        }

        public void SearchVaga(object sender, TextChangedEventArgs args)
        {
            var text = args.NewTextValue;
            var lista = this.Lista.Where(v => v.Nome.Contains(text)).ToList();
            ListVagas.ItemsSource = lista;
            LabelCount.Text = $"{lista.Count} Vagas cadastradas encontradas";
        }

        public void ExcluirVaga(object sender, EventArgs args)
        {
            if (sender is Label l) {
                if (l.GestureRecognizers[0] is TapGestureRecognizer tap) {
                    if (tap.CommandParameter is Vaga v) {
                        App.DBVagas.Remover(v);
                        this.AtualizarLista();
                    }
                }
            }
        }
    }
}