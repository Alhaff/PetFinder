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
    public partial class BalancePage : ContentPage
    {
        public BalancePage()
        {
            InitializeComponent();           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var customer = (User)BindingContext;

            int remainingCoffeeNum = (int)(customer.Balance / 7);
            RemainingCoffee.Text = String.Format("You can purchase {0} more coffees", remainingCoffeeNum);

            int specialsCount = 10 - customer.SpecialCount;
            SpecialsText.Text = String.Format("Make {0} more purcahses to receive a free coffee", specialsCount);
        }
    }
}