using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coffee.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            LoginButton.HeightRequest = Application.Current.MainPage.Height * 0.05;
            LoginButton.WidthRequest = Application.Current.MainPage.Width / 2;

            HelpButton.WidthRequest = LoginButton.WidthRequest;
            HelpButton.HeightRequest = LoginButton.HeightRequest;

            AboutPetFinderButton.WidthRequest = LoginButton.WidthRequest;
            AboutPetFinderButton.HeightRequest = LoginButton.HeightRequest;

            WhyTrustUsButton.WidthRequest = LoginButton.WidthRequest;
            WhyTrustUsButton.HeightRequest = LoginButton.HeightRequest;
        }

        async void onLoginButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("onLoginButtonClicked");
            await Navigation.PushAsync(new LoginPage
            {
                BindingContext = this.BindingContext
            });
        }
        async void onHelpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("onHelpButtonClicked");
            await Navigation.PushAsync(new LoginPage
            {
                BindingContext = this.BindingContext
            });
        }
        async void onAboutPetFinderButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("onAboutPetFinderButtonClicked");
            await Navigation.PushAsync(new LoginPage
            {
                BindingContext = this.BindingContext
            });
        }
         async void onWhyTrustUsButtonClicked(object sender, EventArgs e)
         {
             Console.WriteLine("onWhyTrustUsButtonClicked");
             await Navigation.PushAsync(new LoginPage
             {
                 BindingContext = this.BindingContext
             });
         }
    }
}