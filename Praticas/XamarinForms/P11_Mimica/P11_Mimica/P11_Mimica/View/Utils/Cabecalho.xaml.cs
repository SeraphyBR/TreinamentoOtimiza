using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P11_Mimica.View.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cabecalho : ContentView
    {
        public Cabecalho()
        {
            InitializeComponent();
            BindingContext = new ViewModel.CabecalhoViewModel();
        }

        public void SairEvent(object sender, EventArgs args)
        {
            var viewModel = this.BindingContext as ViewModel.CabecalhoViewModel;
            if (viewModel.Sair.CanExecute(null)) {
                viewModel.Sair.Execute(null);
            }
        }
    }
}