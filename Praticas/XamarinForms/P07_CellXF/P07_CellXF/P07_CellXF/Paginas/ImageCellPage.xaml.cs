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
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();
            var lista = new List<Funcionario>() {
                new Funcionario(){
                    Foto = "https://www.autodata.com.br/admin/imagens/foto-perfil-generica.jpg",
                    Nome = "José",
                    Cargo = "Presidente da Empresa"
                },
                new Funcionario(){
                    Foto = "https://www.autodata.com.br/admin/imagens/foto-perfil-generica.jpg",
                    Nome = "Maria",
                    Cargo = "Gerente de Vendas"
                },
                new Funcionario(){
                    Foto = "https://www.autodata.com.br/admin/imagens/foto-perfil-generica.jpg",
                    Nome = "Elaine",
                    Cargo = "Gerente de Marketing"
                },
                new Funcionario(){
                    Foto = "https://www.autodata.com.br/admin/imagens/foto-perfil-generica.jpg",
                    Nome = "Felipe",
                    Cargo = "Entregador"
                },
                new Funcionario(){
                    Foto = "https://www.autodata.com.br/admin/imagens/foto-perfil-generica.jpg",
                    Nome = "João",
                    Cargo = "Vendedor"
                },
            };

            ListFuncionario.ItemsSource = lista;
		}
	}
}