using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderStepperPage : ContentPage
    {
        public SliderStepperPage()
        {
            InitializeComponent();
        }

        private void HandleValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender is Stepper) {
                LabelStepperValue.Text = args.NewValue.ToString();
            }
            if (sender is Slider) {
                LabelSliderValue.Text = args.NewValue.ToString();
            }
        }
    }
}