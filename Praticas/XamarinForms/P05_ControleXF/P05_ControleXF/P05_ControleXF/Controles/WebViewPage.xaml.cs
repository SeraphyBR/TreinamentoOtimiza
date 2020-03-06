using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();
		}

        private void HandleClickedEvent(object sender, EventArgs args)
        {
            switch (sender) {
                case Button bt:
                    switch (bt) {
                        case var b when b.Equals(ButtonEnterPage):
                            WebView1.Source = EntryEndereco.Text;
                            break;
                        case var b when b.Equals(ButtonBack):
                            if (WebView1.CanGoBack) WebView1.GoBack();
                            break;
                        case var b when b.Equals(ButtonNext):
                            if (WebView1.CanGoForward) WebView1.GoForward();
                            break;
                    }
                    break;
                default:
                    break;
            } 
            
        }

        private void HandleNavigatedEvent(object sender, EventArgs args)
        {
            LabelStatus.Text = "Concluído";
        }

        private void HandleNavigatingEvent(object sender, EventArgs args)
        {
            LabelStatus.Text = "Carregando...";
        }
	}
}