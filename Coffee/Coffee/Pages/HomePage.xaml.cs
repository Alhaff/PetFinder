using System;
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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var customer = (Customer)BindingContext;
            HomeBalance.Text = String.Format("${0}.00", customer.Balance);
        }

        async void OnOrderCoffeeButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Order Coffee");
            await Navigation.PushAsync(new CoffeeSelectPage
            {
                BindingContext = this.BindingContext
            });
        }

        async void OnOrderDoughnutButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Order Doughnut");
            await Navigation.PushAsync(new DoughnutSelectPage(this.BindingContext as Customer, new List<CoffeeData>(), new Order(), "Order List:"));
        }


        async void OnTopUpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Top Up");
            await Navigation.PushAsync(new BankPage
            {
                BindingContext = this.BindingContext
            });
        }

        async void OnAccountDetailsButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("User Page");
            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = this.BindingContext
            });
        }

        void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}