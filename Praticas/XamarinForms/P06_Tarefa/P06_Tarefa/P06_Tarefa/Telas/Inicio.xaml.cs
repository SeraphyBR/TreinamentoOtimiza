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
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
            var day = DateTime.Now.DayOfWeek.ToString();
            var date = DateTime.Now.ToString("dd/MM");
            LabelToday.Text = $"{day}, {date}";
            this.LoadTarefas();
		}

        private void ToCadastroPage(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void LoadTarefas()
        {
            StackTarefas.Children.Clear();
            var lista = new GerenciadorTarefa().Lista;
            foreach(Tarefa t in lista) {
                this.AddLinhaStackLayout(t);
            }
        }

        public void AddLinhaStackLayout(Tarefa t)
        {
            var linha = new StackLayout() {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15
            };

            var ImgCheck = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("CheckOff.png")
            };
            if (Device.RuntimePlatform == Device.UWP) {
                ImgCheck.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }

            View viewTarefa = null;
            if(t.DataFinalizacao == null) {
                viewTarefa = new Label {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Text = t.Nome
                };
            } else {
                viewTarefa = new StackLayout() {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Spacing = 0
                };
                var stackTarefa = viewTarefa as StackLayout;
                stackTarefa.Children.Add(new Label() {
                    Text = t.Nome,
                    TextColor = Color.Gray
                });
                stackTarefa.Children.Add(new Label() {
                    Text = $"Finalizado em {t.DataFinalizacao.Value.ToString("dd/MM - hh:mm")}",
                    TextColor = Color.Gray,
                    FontSize = 10
                });
            }

            var ImgPrioridade = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile($"{t.Prioridade}.png")
            };
            if (Device.RuntimePlatform == Device.UWP) {
                ImgPrioridade.Source = ImageSource.FromFile($"Resources/{t.Prioridade}.png");
            }

            var ImgDelete = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("Delete.png")
            };
            if (Device.RuntimePlatform == Device.UWP) {
                ImgDelete.Source = ImageSource.FromFile("Resources/Delete.png");
            }
             
            linha.Children.Add(ImgCheck);
            linha.Children.Add(viewTarefa);
            linha.Children.Add(ImgPrioridade);
            linha.Children.Add(ImgDelete);

            StackTarefas.Children.Add(linha);

        }
	}
}