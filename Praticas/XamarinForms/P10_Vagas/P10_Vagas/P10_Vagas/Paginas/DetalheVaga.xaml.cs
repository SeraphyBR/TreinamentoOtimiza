using P10_Vagas.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheVaga : ContentPage
    {
        public DetalheVaga(Vaga v)
        {
            InitializeComponent();
            BindingContext = v;
        }
    }
}