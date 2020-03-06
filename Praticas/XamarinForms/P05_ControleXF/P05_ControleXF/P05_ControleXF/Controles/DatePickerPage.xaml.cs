using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePickerPage : ContentPage
    {
        public DatePickerPage()
        {
            InitializeComponent();
        }

        private void HandleDateSelected(object sender, DateChangedEventArgs args)
        {
            LabelResultado.Text = $"{args.OldDate.ToString("dd/MM/yyyy")} > {args.NewDate.ToString("dd/MM/yyyy")}";
        }
    }
}