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
	public partial class ViewCellPage : ContentPage
	{
		public ViewCellPage ()
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
	}
}