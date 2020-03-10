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
	public partial class DetailPage : ContentPage
	{
		public DetailPage (Funcionario f)
		{
			InitializeComponent ();
            LabelName.Text = f.Nome;
		}
	}
}