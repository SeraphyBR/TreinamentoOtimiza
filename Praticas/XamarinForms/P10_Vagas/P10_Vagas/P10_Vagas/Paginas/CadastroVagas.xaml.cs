using P10_Vagas.Modelos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroVagas : ContentPage
    {
        public CadastroVagas()
        {
            InitializeComponent();
        }

        public void HandleClickedEvent(object sender, EventArgs args)
        {
            if (sender is Button bt) {
                if (bt.Equals(ButtonSalvar)) {
                    //TODO - Validar os dados
                    var v = new Vaga() {
                        Nome = EntryVaga.Text,
                        Empresa = EntryEmpresa.Text,
                        Quantidade = short.Parse(EntryQuantidade.Text),
                        Cidade = EntryCidade.Text,
                        Salario = double.Parse(EntrySalario.Text),
                        Descricao = EditorDescricao.Text,
                        TipoContratacao = SwitchTipoContratacao.IsToggled ? TypeContratacao.PJ : TypeContratacao.CLT,
                        Telefone = EntryTelefone.Text,
                        Email = EntryEmail.Text
                    };
                    App.DBVagas.Adicionar(v);
                    App.Current.MainPage = new NavigationPage(new ConsultaVaga());
                }
            }
        }
    }
}