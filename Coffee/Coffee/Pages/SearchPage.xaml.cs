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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            PetType.ItemsSource = (await App.Database.GetPetTypeList()).Select(p => p.TypeName).ToList();

            PetGender.ItemsSource = new List<string> { "Male", "Female" };
        }
        bool TimeUpSelected { get; set; } = false;
        bool TimeDownSelected { get; set; } = false;
        private void TimeDownButton_Clicked(object sender, EventArgs e)
        {
            if(TimeUpSelected)
            {
                TimeUpSelected = false;
                TimeUpButton.BackgroundColor = Color.FromHex("#dfa158");
            }
            TimeDownSelected = !TimeDownSelected;
            if (TimeDownSelected)
            {
                TimeDownButton.BackgroundColor = Color.DarkOrange;
            }
            else
            {
                TimeDownButton.BackgroundColor = Color.FromHex("#dfa158");
            }
        }
       
        private void TimeUpButton_Clicked(object sender, EventArgs e)
        {
            if (TimeDownSelected)
            {
                TimeDownSelected = false;
                TimeDownButton.BackgroundColor = Color.FromHex("#dfa158"); ;
            }
            TimeUpSelected = !TimeUpSelected;
            if (TimeUpSelected)
            {
                TimeUpButton.BackgroundColor = Color.DarkOrange;
            }
            else
            {
                TimeUpButton.BackgroundColor = Color.FromHex("#dfa158");
            }
        }
        bool AgeUpSelected { get; set; }
        bool AgeDownSelected { get; set; }
        private void AgeUpButton_Clicked(object sender, EventArgs e)
        {
            if (AgeDownSelected)
            {
                AgeDownSelected = false;
                AgeDownButton.BackgroundColor = Color.FromHex("#dfa158");
            }
            AgeUpSelected = !AgeUpSelected;
            if (AgeUpSelected)
            {
                AgeUpButton.BackgroundColor = Color.DarkOrange;
            }
            else
            {
                AgeUpButton.BackgroundColor = Color.FromHex("#dfa158");
            }
        }

        private void AgeDownButton_Clicked(object sender, EventArgs e)
        {
            if (AgeUpSelected)
            {
                AgeUpSelected = false;
                AgeUpButton.BackgroundColor = Color.FromHex("#dfa158"); ;
            }
            AgeDownSelected = !AgeDownSelected;
            if (AgeDownSelected)
            {
                AgeDownButton.BackgroundColor = Color.DarkOrange;
            }
            else
            {
                AgeDownButton.BackgroundColor = Color.FromHex("#dfa158");
            }
        }
        private async void ApplySearch_Clicked(object sender, EventArgs e)
        {
            var lst = await App.Database.GetPostPetPair();
            var typeList = await App.Database.GetPetTypeList();
            var str = (string)PetType.SelectedItem;
            var selectedPetId = typeList.Where(t => t.TypeName == str).Select(p => p.ID).FirstOrDefault();
            var tempList1 = lst.Where(t => t.Item2.PetTypeID == selectedPetId);
            if (tempList1.Count() == 0) tempList1 = lst;
            var tempList = tempList1.Where(t => t.Item2.Gender == (string)PetGender.SelectedItem);
            if (tempList.Count() == 0) tempList = tempList1;
            if(AgeDownSelected)
            {
                tempList = tempList.OrderBy(t => t.Item2.Age);
            }
            else if (AgeUpSelected) 
            {
                tempList = tempList.OrderByDescending(t => t.Item2.Age);
            }

            if(TimeDownSelected)
            {
                tempList = tempList.OrderBy(t => t.Item1.PublishingTime);
            }
            else if(TimeUpSelected)
            {
                tempList = tempList.OrderByDescending(t => t.Item1.PublishingTime);
            }

            App.Current.MainPage = new NavigationPage(new HomePage(tempList.ToList())
            {
                BindingContext = this.BindingContext
            });
        }

    }
}