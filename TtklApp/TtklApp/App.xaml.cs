using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TtklApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var np = new NavigationPage(new Nav1Page());
            np.Title = "Page 4";
            np.IconImageSource = "home";

            var tp = new TabbedPage();
            tp.Children.Add(new Tab1Page());
            tp.Children.Add(new Tab2Page());
            tp.Children.Add(new Tab3Page());
            tp.Children.Add(np);

            var mp = new MasterDetailPage();
            mp.Master = new MenuPage();
            mp.Detail = new NavigationPage(new MainPage());

            MainPage = mp;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
