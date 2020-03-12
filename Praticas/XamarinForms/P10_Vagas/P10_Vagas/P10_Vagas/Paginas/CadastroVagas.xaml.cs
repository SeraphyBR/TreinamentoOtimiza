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
	public partial class CadastroVagas : ContentPage
	{
		public CadastroVagas ()
		{
			InitializeComponent ();
		}

        public void HandleClickedEvent(object sender, EventArgs args)
        {
            if(sender is Button bt) {
                if (bt.Equals(ButtonSalvar)) {
                    //TODO - Validar os dados
                    var v = new Vaga() {
                        Nome = EntryVaga.Text,
                        Empresa = EntryEmpresa.Text,
                        Quantidade = short.Parse(EntryQuantidade.Text),
                        Cidade = EntryCidade.Text,
                        Salario = double.Parse(EntrySalario.Text),
                        Descricao = EditorDescricao.Text,
                        TipoContratacao = SwitchTipoContratacao.IsToggled ? "PJ" : "CLT",
                        Telefone = EntryTelefone.Text,
                        Email = EntryEmail.Text
                    };
                    var db = new Database("vagas");
                    db.Adicionar(v);
                    Navigation.PopAsync();
                }
            }
        }
	}
}