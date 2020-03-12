using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using P10_Vagas.Modelos;

namespace P10_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheVaga : ContentPage
	{
		public DetalheVaga (Vaga v)
		{
			InitializeComponent ();
            DisplayAlert("Msg", v.Nome, "Ok");
		}
	}
}