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
    public partial class Nav2Page : ContentPage
    {
        public Nav2Page()
        {
            InitializeComponent();
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Nav3Page());
        }
    }
}