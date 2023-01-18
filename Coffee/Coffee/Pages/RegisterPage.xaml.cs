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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public Boolean DetailsFilledIn()
        {
            return (Username.Text != "" && Name.Text != "" && EmailAddress.Text != "" && Password.Text == "");
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Sign Up");
            if (true)
            {
                var customer = (User)BindingContext;
                var checkCustomer = await App.Database.UserNameExists(customer.UserName, customer.EmailAddress);
                if (checkCustomer != null)
                {
                    await DisplayAlert("Error", "Username and/or Email already exists", "OK");
                }
                else
                {
                    await DisplayAlert("Complete", "User has been created", "OK");
                    await App.Database.SaveCustomer(customer);
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Error", "Please fill in all details", "OK");
            }
                     
        }
    }
}