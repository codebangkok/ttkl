using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TtklApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as MasterDetailPage;
            mp.Detail = new NavigationPage(new MainPage());
            mp.IsPresented = false;
        }

        private void NavButton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as MasterDetailPage;
            mp.Detail = new NavigationPage(new Nav1Page());
            mp.IsPresented = false;
        }

        private void TabButton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as MasterDetailPage;

            var tp = new TabbedPage();
            tp.Children.Add(new Tab1Page());
            tp.Children.Add(new Tab2Page());
            tp.Children.Add(new Tab3Page());

            mp.Detail = new NavigationPage(tp);
            mp.IsPresented = false;
        }

        private void ProductButton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as MasterDetailPage;
            mp.Detail = new NavigationPage(new ProductPage());
            mp.IsPresented = false;
        }
    }
}