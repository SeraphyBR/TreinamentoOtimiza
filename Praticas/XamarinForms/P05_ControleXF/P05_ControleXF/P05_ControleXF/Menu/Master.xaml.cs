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
            Detail = new NavigationPage(new Controles.ActivityIndicatorPage());
            IsPresented = false;
        }

        private void ToProgressBarPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ProgressBarPage());
            IsPresented = false;
        }

        private void ToBoxViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.BoxViewPage());
            IsPresented = false;
        }

        private void ToLabelPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.LabelPage());
            IsPresented = false;
        }

        private void ToButtonPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ButtonPage());
            IsPresented = false;
        }

        private void ToEntryEditorPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.EntryEditorPage());
            IsPresented = false;
        }

        private void ToDatePickerPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.DatePickerPage());
            IsPresented = false;
        }

        private void ToTimePickerPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.TimePickerPage());
            IsPresented = false;
        }

        private void ToPickerPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.PickerPage());
            IsPresented = false;
        }

        private void ToSearchBarPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.SearchBarPage());
            IsPresented = false;
        }

        private void ToSliderStepperPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.SliderStepperPage());
            IsPresented = false;
        }

        private void ToSwitchPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.SwitchPage());
            IsPresented = false;
        }

        private void ToImagePage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ImagePage());
            IsPresented = false;
        }

        private void ToListViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ListViewPage());
            IsPresented = false;
        }

        private void ToTableViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.TableViewPage());
            IsPresented = false;
        }

        private void ToWebViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.WebViewPage());
            IsPresented = false;
        }
    }
}