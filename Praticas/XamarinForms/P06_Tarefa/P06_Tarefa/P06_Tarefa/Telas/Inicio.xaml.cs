using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using P06_Tarefa.Modelos;
using System.Globalization;

namespace P06_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
            CultureInfo culture = new CultureInfo("pt-BR");
            string data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture);
            LabelToday.Text = string.Format(data, "de");
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
            int i = 0;
            foreach(Tarefa t in lista) {
                this.AddLinhaStackLayout(t, i++);
            }
        }

        public void AddLinhaStackLayout(Tarefa t, int idx)
        {
            var linha = new StackLayout() {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15
            };

            var ImgCheck = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("CheckOff.png")
            };

            TapGestureRecognizer checkTap = new TapGestureRecognizer();
            checkTap.Tapped += delegate {
                new GerenciadorTarefa().Finalizar(idx, DateTime.Now);
                this.LoadTarefas();
            };
            ImgCheck.GestureRecognizers.Add(checkTap);

            if (Device.RuntimePlatform == Device.UWP) {
                ImgCheck.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }
            if(t.DataFinalizacao != null) {
                ImgCheck.Source = ImageSource.FromFile("CheckOn.png");
                if (Device.RuntimePlatform == Device.UWP) {
                    ImgCheck.Source = ImageSource.FromFile("Resources/CheckOn.png");
                }   
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
                Source = ImageSource.FromFile($"p{t.Prioridade}.png")
            };
            if (Device.RuntimePlatform == Device.UWP) {
                ImgPrioridade.Source = ImageSource.FromFile($"Resources/p{t.Prioridade}.png");
            }

            var ImgDelete = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("Delete.png"),
            };
            TapGestureRecognizer deleteTap = new TapGestureRecognizer();
            deleteTap.Tapped += delegate {
                new GerenciadorTarefa().Remover(idx);
                this.LoadTarefas();
            };
            ImgDelete.GestureRecognizers.Add(deleteTap);

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