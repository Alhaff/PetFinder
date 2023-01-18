using Coffee.Models;
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
    public partial class PetPage : ContentPage
    {
        public PetPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (listView.ItemsSource == null)
            {
                listView.ItemsSource = await App.Database.GetPostPetShelterPair((Tuple<Post, Pet>)this.BindingContext);
            }

            listView.ItemsSource.ToString();
        }
        async void OnAccountDetailsButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Account Details");
            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = this.BindingContext
            });
        }
        private void Home_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePage
            {
                BindingContext = App.Database.LoginedUser
            });
        }
    }
}