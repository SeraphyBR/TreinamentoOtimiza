using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using P10_Vagas.Modelos;
using P10_Vagas.Banco;

namespace P10_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaVaga : ContentPage
	{
		public ConsultaVaga ()
		{
			InitializeComponent ();
            var db = new Database("vagas");
            var lista = db.Consultar();
            ListaVagas.ItemsSource = lista;
            LabelCount.Text = $"{lista.Count} vagas encontradas";
		}

        public void HandleClickedEvent(object sender, EventArgs args)
        {
            if(sender is Button bt) {
                if (bt.Equals(ButtonCadastraVaga)) {
                    Navigation.PushAsync(new CadastroVagas());
                }
                if (bt.Equals(ButtonMinhasVagas)) {
                    Navigation.PushAsync(new VagasCadastradas());
                }
            }
        }

        public void ShowDetalhes(object sender, EventArgs args)
        {
            if(sender is Label l) {
                if (l.GestureRecognizers[0] is TapGestureRecognizer tap) {
                    if (tap.CommandParameter is Vaga v) {
                        Navigation.PushAsync(new DetalheVaga(v));
                    }
                }
            }
        }
	}
}