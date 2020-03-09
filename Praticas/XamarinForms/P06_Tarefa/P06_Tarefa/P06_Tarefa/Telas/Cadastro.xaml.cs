using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using P06_Tarefa.Modelos;

namespace P06_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        private byte Prioridade { get; set; }

		public Cadastro ()
		{
			InitializeComponent ();
		}

        public void HandleTappedEvent(object sender, EventArgs args)
        {
            var stacks = StackPrioridades.Children;
            foreach(var linha in stacks) {
                if(linha is StackLayout sl) {
                    if(sl.Children[1] is Label prioridade) {
                        prioridade.TextColor = Color.Gray;
                    }
                }
            }

            if(sender is StackLayout s) {
                if(s.Children[1] is Label prioridade) {
                    prioridade.TextColor = Color.Black;
                }
                if(s.Children[0] is Image i) {
                    var source = i.Source as FileImageSource;
                    string nivelp = source.File.ToString()
                        .Replace("Resources/", "")
                        .Replace(".png", "");
                    this.Prioridade = byte.Parse(nivelp);
                }
            }
        }

        public void SalvarTarefa(object sender, EventArgs args)
        {
            bool isError = false;
            if(EntryNome.Text == null || EntryNome.Text.Trim().Length <= 0) {
                isError = true;
                DisplayAlert("Erro", "Nome não preenchido!", "Ok");
            }

            if(this.Prioridade <= 0) {
                isError = true;
                DisplayAlert("Erro", "Prioridade não foi informada!", "Ok");
            }

            if (!isError) {
                Tarefa nova = new Tarefa {
                    Nome = EntryNome.Text.Trim(),
                    Prioridade = this.Prioridade
                };

                var gt = new GerenciadorTarefa();
                gt.Adicionar(nova);
                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
	}
}