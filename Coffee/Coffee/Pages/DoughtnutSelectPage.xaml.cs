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
    public partial class DoughnutSelectPage : ContentPage
    {
        // FOR TESTING
        //public static List<CoffeeData> orderList;
        public static string orderListText;

        public static Agreement neworder;
        public static User customer;

        //public DoughnutSelectPage(User _customer, List<CoffeeData> _orderlist, Agreement _order, string _listText)
        //{
        //    InitializeComponent();
        //    customer = _customer;
        //   // orderList = _orderlist;
        //    neworder = _order;
        //    orderListText = _listText;

        //    OrderList.Text = orderListText;
        //    BalanceText.Text = String.Format("${0}.00", customer.Balance);
        //}


        private void ButtonPlainAdd(object sender, EventArgs e)
        {
            var type = "Donut";
            var size = "Plain";
            int cost = 5;
            if (canPurchase(cost)) DoughnutAdd(type, size, cost);
        }

        private void ButtonChocolateAdd(object sender, EventArgs e)
        {

            var type = "Dount";
            var size = "Chocolate";
            int cost = 6;
            if (canPurchase(cost)) DoughnutAdd(type, size, cost);
        }

        private void ButtonStrawberryAdd(object sender, EventArgs e)
        {
            var type = "Donut";
            var size = "Strawberry";
            int cost = 7;
            if (canPurchase(cost)) DoughnutAdd(type, size, cost);
        }

        public Boolean canPurchase(int cost)
        {
            if (customer.Balance < cost)
            {
                DisplayAlert("Error", "You need to add funds to you balance", "OK");
                return false;
            }
            customer.Balance -= cost;
            
            return true;       
        }

        private async void DoughnutAdd(string type, string size, int cost)
        {
            await App.Database.SaveOrder(neworder);
            //var newDonut = new CoffeeData
            //{
            //    OrderID = neworder.ID,
            //    CoffeeName = type,
            //    Size = size,
            //    Cost = cost
            //};
            //orderList.Add(newDonut);
            //var text = type + " doughnut added to your order";
            //BalanceText.Text = String.Format("${0}.00", customer.Balance);
            //orderListText += String.Format("{2}{0} {1}", size, type, Environment.NewLine);
            //OrderList.Text = orderListText;

            //await DisplayAlert(text, "Place Order when done adding items", "OK");
        }

        private async void ButtonPlaceOrder(object sender, EventArgs e)
        {
            //foreach (var doughnut in orderList)
            //{
            //    neworder.TotalCost += doughnut.Cost;
            //    await App.Database.SaveCoffee(doughnut);
            //}
            //neworder.UserID = customer.ID;
            //neworder.orderTime = DateTime.Now;
            //await App.Database.SaveCustomer(customer);
            //await App.Database.SaveOrder(neworder);
            //await Navigation.PushAsync(new CoffeeConfirmPage(orderList, customer));

        }
    }

}