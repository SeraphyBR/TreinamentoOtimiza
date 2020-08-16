using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P08_EstilosXF.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void HandleClickedEvent(object sender, EventArgs args)
        {
            if (sender is Button btn) {
                if (btn.Equals(ButtonImplicitStylePage)) {
                    Detail = new NavigationPage(new Paginas.ImplicitStylePage());
                    IsPresented = false;
                }
                if (btn.Equals(ButtonExplicitStylePage)) {
                    Detail = new NavigationPage(new Paginas.ExplicitStylePage());
                    IsPresented = false;
                }
                if (btn.Equals(ButtonGlobalStylePage)) {
                    Detail = new NavigationPage(new Paginas.GlobalStylePage());
                    IsPresented = false;
                }
                if (btn.Equals(ButtonInheritStylePage)) {
                    Detail = new NavigationPage(new Paginas.InheritStylePage());
                    IsPresented = false;
                }
                if (btn.Equals(ButtonDynamicStylePage)) {
                    Detail = new NavigationPage(new Paginas.DynamicStylePage());
                    IsPresented = false;
                }
            }
        }
    }
}