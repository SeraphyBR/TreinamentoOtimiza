using P10_Vagas.Modelos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edicao : ContentPage
    {
        private Vaga Vaga { get; set; }

        public Edicao(Vaga v)
        {
            InitializeComponent();
            this.Vaga = v;
            EntryVaga.Text = Vaga.Nome;
            EntryEmpresa.Text = Vaga.Empresa;
            EntryQuantidade.Text = Vaga.Quantidade.ToString();
            EntryCidade.Text = Vaga.Cidade;
            EntrySalario.Text = Vaga.Salario.ToString();
            EditorDescricao.Text = Vaga.Descricao;
            SwitchTipoContratacao.IsToggled = Vaga.TipoContratacao.Equals(TypeContratacao.PJ);
            EntryTelefone.Text = Vaga.Telefone;
            EntryEmail.Text = Vaga.Email;
        }

        public void HandleClickedEvent(object sender, EventArgs args)
        {
            if (sender is Button bt) {
                if (bt.Equals(ButtonSalvar)) {
                    //TODO - Validar os dados
                    this.Vaga.Nome = EntryVaga.Text;
                    this.Vaga.Empresa = EntryEmpresa.Text;
                    this.Vaga.Quantidade = short.Parse(EntryQuantidade.Text);
                    this.Vaga.Cidade = EntryCidade.Text;
                    this.Vaga.Salario = double.Parse(EntrySalario.Text);
                    this.Vaga.Descricao = EditorDescricao.Text;
                    this.Vaga.TipoContratacao = SwitchTipoContratacao.IsToggled ? TypeContratacao.PJ : TypeContratacao.CLT;
                    this.Vaga.Telefone = EntryTelefone.Text;
                    this.Vaga.Email = EntryEmail.Text;
                    App.DBVagas.Atualizar(this.Vaga);
                    App.Current.MainPage = new NavigationPage(new VagasCadastradas());
                }
            }
        }
    }
}