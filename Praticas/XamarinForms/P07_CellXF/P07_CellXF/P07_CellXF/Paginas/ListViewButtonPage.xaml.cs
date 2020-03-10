using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using P07_CellXF.Modelo;

namespace P07_CellXF.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewButtonPage : ContentPage
	{
		public ListViewButtonPage ()
		{
			InitializeComponent ();

            var lista = new List<Funcionario>() {
                new Funcionario(){ Nome = "José", Cargo = "Presidente da Empresa"},
                new Funcionario(){ Nome = "Maria", Cargo = "Gerente de Vendas"},
                new Funcionario(){ Nome = "Elaine", Cargo = "Gerente de Marketing"},
                new Funcionario(){ Nome = "Felipe", Cargo = "Entregador"},
                new Funcionario(){ Nome = "João", Cargo = "Vendedor"},
            };

            ListFuncionarios.ItemsSource = lista;
		}

        private void HandleClickedEvent(object sender, EventArgs args)
        {
            if(sender is Button bt) {
                if(bt.CommandParameter is Funcionario f) {
                    DisplayAlert("Ferias", $"Funcionario: {f.Nome}", "Ok");
                }
            }
        }
	}
}