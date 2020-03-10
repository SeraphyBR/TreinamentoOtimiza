using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P07_CellXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        public void HandleClickedEvent(object sender, EventArgs args)
        {
            if(sender is Button bt) {
                if (bt.Equals(ButtonTextCellPage)) {
                    Detail = new NavigationPage(new Paginas.TextCellPage());
                    IsPresented = false;
                }
                if (bt.Equals(ButtonImageCellPage)) {
                    Detail = new NavigationPage(new Paginas.ImageCellPage());
                    IsPresented = false;
                }
                if (bt.Equals(ButtonEntryCellPage)) {
                    Detail = new NavigationPage(new Paginas.EntryCellPage());
                    IsPresented = false;
                }
                if (bt.Equals(ButtonSwitchCellPage)) {
                    Detail = new NavigationPage(new Paginas.SwitchCellPage());
                    IsPresented = false;
                }
                if (bt.Equals(ButtonViewCellPage)) {
                    Detail = new NavigationPage(new Paginas.ViewCellPage());
                    IsPresented = false;
                }
                if (bt.Equals(ButtonListViewPage)) {
                    Detail = new NavigationPage(new Paginas.ListViewPage());
                    IsPresented = false;
                }
                if (bt.Equals(ButtonListViewButtonPage)) {
                    Detail = new NavigationPage(new Paginas.ListViewButtonPage());
                    IsPresented = false;
                }
            }
        }
	}
}