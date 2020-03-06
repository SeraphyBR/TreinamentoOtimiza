using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P05_ControleXF.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void ToActivityIndicatorPage(object sender, EventArgs args)
        {
            Detail = new Controles.ActivityIndicatorPage();
        }

        private void ToProgressBarPage(object sender, EventArgs args)
        {
            Detail = new Controles.ProgressBarPage();
        }

        private void ToBoxViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.BoxViewPage();
        }

        private void ToLabelPage(object sender, EventArgs args)
        {
            Detail = new Controles.LabelPage();
        }

        private void ToButtonPage(object sender, EventArgs args)
        {
            Detail = new Controles.ButtonPage();
        }

        private void ToEntryEditorPage(object sender, EventArgs args)
        {
            Detail = new Controles.EntryEditorPage();
        }

        private void ToDatePickerPage(object sender, EventArgs args)
        {
            Detail = new Controles.DatePickerPage();
        }

        private void ToTimePickerPage(object sender, EventArgs args)
        {
            Detail = new Controles.TimePickerPage();
        }

        private void ToPickerPage(object sender, EventArgs args)
        {
            Detail = new Controles.PickerPage();
        }

        private void ToSearchBarPage(object sender, EventArgs args)
        {
            Detail = new Controles.SearchBarPage();
        }

        private void ToSliderStepperPage(object sender, EventArgs args)
        {
            Detail = new Controles.SliderStepperPage();
        }
        private void ToSwitchPage(object sender, EventArgs args)
        {
            Detail = new Controles.SwitchPage();
        }
        private void ToImagePage(object sender, EventArgs args)
        {
            Detail = new Controles.ImagePage();
        }
        private void ToListViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.ListViewPage();
        }
        private void ToTableViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.TableViewPage();
        }
        private void ToWebViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.WebViewPage();
        }
    }
}