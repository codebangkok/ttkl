using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TtkLib.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TtklApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var client = new HttpClient();
            client.BaseAddress = Helpers.Setting.ApiAddress;
            var response = await client.GetAsync("api/products/getall");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                productListView.ItemsSource = products;
            }
           
        }

        private async void ProductListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            //DisplayAlert(product.ProductName, product.CategoryName, "OK");
            await Navigation.PushAsync(new ProductDetailPage(product));
            productListView.SelectedItem = null;
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductNewPage());
        }
    }
}