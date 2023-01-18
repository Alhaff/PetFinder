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
    public partial class CoffeeSelectPage : ContentPage
    {
        //public static List<CoffeeData> coffeeList;
        public static Agreement neworder;

        public static Boolean canOrder = false;
        public static string coffeeListText;
        public CoffeeSelectPage()
        {
            InitializeComponent();
            neworder = new Agreement();
            //coffeeList = new List<CoffeeData>();
            coffeeListText = "Order List:";
        }

        private void AddCoffee(object sender, EventArgs e)
        {
            DisplayAlert("Coffee Added", "Don't forget to click Place Order when done", "OK");
            
        }

        private void ButtonEspressoAdd(object sender, EventArgs e)
        {
            var type = "Espresso";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 5;
            size = GetNiceSize(size);
            if (canPurchase(cost)) CoffeeAdd(type, size, cost);
        }

        private void ButtonLongBlackAdd(object sender, EventArgs e)
        {

            var type = "Long Black";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 6;
            size = GetNiceSize(size);
            if (canPurchase(cost)) CoffeeAdd(type, size, cost);
        }

        private void ButtonCappuccinoAdd(object sender, EventArgs e)
        {
            var type = "Cappuccino";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 7;
            size = GetNiceSize(size);
            if (canPurchase(cost)) CoffeeAdd(type, size, cost);
        }

        private void ButtonLatteAdd(object sender, EventArgs e)
        {
            var type = "Latte";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 5;
            size = GetNiceSize(size);
            if (canPurchase(cost)) CoffeeAdd(type, size, cost);
        }

        private void ButtonFlatWhiteAdd(object sender, EventArgs e)
        {
            var type = "Flat White";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 4;
            size = GetNiceSize(size);
            if(canPurchase(cost)) CoffeeAdd(type, size, cost);
        }

        private string GetNiceSize(string s)
        {
            var size = "";

            if (s == "S")
            {
                size = "Small ";
            }
            else if (s == "M")
            {
                size = "Medium ";
            }
            else if (s == "L")
            {
                size = "Large ";
            }
            return size;
        }

        public static (bool, bool) GetSugarSoyOption(string option)
        {
            bool Sugar = false;
            bool Soy = false;

            if (option == "Sugar")
            {
                Sugar = true;
            }
            else if (option == "SoyMilk")
            {
                Soy = true;
            }
            else if (option == "Sugar & SoyMilk")
            {
                Sugar = true;
                Soy = true;
            }

            return (Sugar, Soy);
        }

        public Boolean canPurchase(int cost)
        {
            var customer = (User)BindingContext;
            if (customer.Balance < cost)
            {
                DisplayAlert("Error", "You need to add funds to you balance", "OK");
                return false;
            }
            customer.Balance -= cost;           
            return true;       
        }

        private async void CoffeeAdd(string type, string size, int cost)
        {
            canOrder = true;
            string action = await DisplayActionSheet("Customise your coffee?", "Cancel Order", null, "Standard " + type, "Sugar", "SoyMilk", "Sugar & SoyMilk");
            (bool sugar, bool soy) = GetSugarSoyOption(action);

            if (action == "Cancel Order" || action == null)
            {
                await DisplayAlert("", "Order Cancelled", "OK");
            }

            else
            {
                await App.Database.SaveOrder(neworder);

                //var newcoffee = new CoffeeData
                //{
                //    OrderID = neworder.ID,
                //    CoffeeName = type,
                //    Size = size,
                //    Cost = cost,
                //    SoyMilk = soy,
                //    Sugar = sugar
                //};

                //coffeeList.Add(newcoffee);

                var text = String.Concat(size, type, " added to your order");

                if (action == "Standard " + type)
                {
                    action = "Standard";
                }

                coffeeListText += String.Format("{2}{0} {1}({3})", type, size, Environment.NewLine, action);
                OrderList.Text = coffeeListText;

                await DisplayAlert(text, "Place Order when done adding items", "OK");
            }
        }

        private void checkSpecials(User customer)
        {
            if(customer.SpecialCount >= 10)
            {
                customer.SpecialEnabled = true;
                customer.SpecialCount -= 10;
            }
            else
            {
                customer.SpecialEnabled = false;
            }
        }

        private async void ButtonPlaceOrder(object sender, EventArgs e)
        {
            if (canOrder)
            {
                //canOrder = false;
                //foreach (var coffee in coffeeList)
                //{
                //    neworder.TotalCost += coffee.Cost;
                //    await App.Database.SaveCoffee(coffee);
                //}
                //var customer = (User)BindingContext;
                //customer.SpecialCount += coffeeList.Count;
                //checkSpecials(customer);
                //neworder.UserID = customer.ID;
                //neworder.orderTime = DateTime.Now;
                //await App.Database.SaveCustomer(customer);
                //await App.Database.SaveOrder(neworder);
                //await Navigation.PushAsync(new DoughnutSelectPage(customer, coffeeList, neworder, coffeeListText));
                
            }
            else
            {
                await DisplayAlert("Error", "Please add a coffee to your order", "OK");
            }
            
        }
    }

}