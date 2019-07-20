﻿using Newtonsoft.Json;
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
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage()
        {
            InitializeComponent();
        }

        public ProductDetailPage(Product product) : this()
        {
            idEntry.Text = product.ProductID.ToString();
            nameEntry.Text = product.ProductName;
            priceEntry.Text = product.UnitPrice.ToString("N0");
            disconSwitch.IsToggled = product.Discontinued;
        }

        private async void OkButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Save", "Do you want save?", "OK", "Cancel");

            if (isOk)
            {
                var client = new HttpClient();
                client.BaseAddress = Helpers.Setting.ApiAddress;

                var product = new Product();
                product.ProductID = int.Parse(idEntry.Text);
                product.ProductName = nameEntry.Text;
                product.UnitPrice = int.Parse(priceEntry.Text);
                product.Discontinued = disconSwitch.IsToggled;

                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("api/products/put", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    isOk = bool.Parse(result);

                    if (isOk) await Navigation.PopAsync();
                    else await DisplayAlert("Warning", "Cannot save, please contact administrator", "OK");
                }
                else await DisplayAlert("Warning", response.StatusCode.ToString(), "OK");
            }
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Cancel", "Do you want cancel?", "OK", "Cancel");

            if (isOk) await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Delete", "Do you want delete?", "OK", "Cancel");

            if (isOk)
            {
                var client = new HttpClient();
                client.BaseAddress = Helpers.Setting.ApiAddress;

                var response = await client.DeleteAsync("api/products/delete/" + idEntry.Text);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    isOk = bool.Parse(result);

                    if (isOk) await Navigation.PopAsync();
                    else await DisplayAlert("Warning", "Cannot delete, please contact administrator", "OK");
                }
                else await DisplayAlert("Warning", response.StatusCode.ToString(), "OK");
            }
        }
    }
}