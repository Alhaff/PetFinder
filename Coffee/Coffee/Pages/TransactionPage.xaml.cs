﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Coffee.Models;

namespace Coffee.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionPage : ContentPage
    {
        public TransactionPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var customer = (Customer)BindingContext;
            listView.ItemsSource = await App.Database.GetOrderList(customer);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var a = e.SelectedItem as Order;
                Console.WriteLine(a.CustomerID);
                await Navigation.PushAsync(new CoffeeOrderPage
                {
                    BindingContext = e.SelectedItem as Order
                });
            }
        }
    }
}