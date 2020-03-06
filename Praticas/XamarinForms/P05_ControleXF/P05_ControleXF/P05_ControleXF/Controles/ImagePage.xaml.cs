using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();
            //ImageOne.IsLoading
            Image imgUSB = new Image();

            if (Device.RuntimePlatform == Device.UWP) {
                imgUSB.Source = ImageSource.FromFile("Imagens/usb.jpg");
            }
            else {
                imgUSB.Source = ImageSource.FromFile("usb.jpg");
            }

            StackLayout1.Children.Add(imgUSB);
        }
    }
}