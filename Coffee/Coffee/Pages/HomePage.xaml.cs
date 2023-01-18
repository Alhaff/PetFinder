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
        public HomePage(List<Tuple<Post,Pet>> list = null)
        {
            InitializeComponent();
            if(list != null)
            {
                listView.ItemsSource = list;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (listView.ItemsSource == null)
            {
                listView.ItemsSource = await App.Database.GetPostPetPair();
            }
            
            listView.ItemsSource.ToString();
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
           // await Navigation.PushAsync(new DoughnutSelectPage(this.BindingContext as User, new List<CoffeeData>(), new Agreement(), "Order List:"));
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
            Console.WriteLine("Account Details");
            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = this.BindingContext
            });
        }

        void OnLogoutButtonClicked(object sender, EventArgs e)
        {
           // App.Database.DeleteSomeData();
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        async void MoreInfoClicked(object sender, EventArgs e)
        {
            Console.WriteLine("More info");
            Button button = (Button)sender;
            Grid listViewItem = (Grid)button.Parent;
            var info = (Tuple<Post,Pet>)listViewItem.BindingContext;
            await Navigation.PushAsync(new PetPage
            {
                BindingContext = info
            });
        }

        private async void InitializePetType()
        {
            var typeList = new List<PetType>()
            {
                new PetType() {TypeName = "Cat"},
                new PetType() {TypeName = "Dog"},
                new PetType() {TypeName = "Parrot"},
                new PetType() {TypeName = "Fish"}
            };
            foreach (var type in typeList)
            {
                await App.Database.SavePetType(type);
            }
        }
        private async void InitializePetShelter()
        {
            var tmp = new List<PetShelter>()
            {
                new PetShelter() {
                                  Name = "Перший Київський притулок",
                                  ContactPhone="+380676571072",
                                  Address="м.Київ вул. Хрещатик 1а"},
                new PetShelter() {
                                  Name = "Чотири лапе щастя",
                                  ContactPhone="+380996419755",
                                  Address="м.Київ вул. Підлісна 34а"},
                new PetShelter() {
                                  Name = "Ангельскі крила",
                                  ContactPhone="+380678933065",
                                  Address="м.Київ пр. Перемоги 9б"},
            };
            foreach (var item in tmp)
            {
                await App.Database.SavePetShelter(item);
            }
        }
        private async void InitializePet()
        {
            var tmp = new List<Pet>()
            {
                new Pet() {
                            PetName="Мурко",
                            PetTypeID=1,
                            ShelterID=1,
                            Gender="Male",
                            Age=5,
                            ImagePath="cat1"},
              new Pet() {
                            PetName="Мицик",
                            PetTypeID=1,
                            ShelterID=2,
                            Gender="Male",
                            Age=7,
                            ImagePath="cat2"},
               new Pet() {  
                            PetName="Капітан",
                            PetTypeID=1,
                            ShelterID=3,
                            Gender="Male",
                            Age=10,
                            ImagePath="cat3"},
               new Pet() {  
                            PetName="Фіона",
                            PetTypeID=1,
                            ShelterID=2,
                            Gender="Female",
                            Age=9,
                            ImagePath="cat4"},
               new Pet() { 
                            PetName="Кльопа",
                            PetTypeID=1,
                            ShelterID=3,
                            Gender="Female",
                            Age=1,
                            ImagePath="cat5"},
               new Pet() {  
                            PetName="Гавко",
                            PetTypeID=2,
                            ShelterID=1,
                            Gender="Male",
                            Age=5,
                            ImagePath="dog1"},
              new Pet() {   
                            PetName="Розбійник",
                            PetTypeID=2,
                            ShelterID=2,
                            Gender="Male",
                            Age=7,
                            ImagePath="dog2"},
               new Pet() {  
                            PetName="Боцман",
                            PetTypeID=2,
                            ShelterID=3,
                            Gender="Male",
                            Age=10,
                            ImagePath="dog3"},
               new Pet() { 
                            PetName="Кана",
                            PetTypeID=2,
                            ShelterID=1,
                            Gender="Female",
                            Age=9,
                            ImagePath="dog4"},
               new Pet() {  
                            PetName="Загадка",
                            PetTypeID=2,
                            ShelterID=3,
                            Gender="Female",
                            Age=5,
                            ImagePath="dog5"}
            };
            foreach (var item in tmp)
            {
                await App.Database.SavePet(item);
            }
        }

        private async void InitializePost()
        {
            var tmp2 = new List<Post>();
            tmp2.Add(new Post()
            {
                PetID = 1,
                Description = "Сірий кіт у чорну смужку шукає доброго господаря чи господиню. Маю важкий норов, але завжди готовий поділитися обіймами і любов'ю",
                PublishingTime = new DateTime(2023, 1, 11)
            });
            tmp2.Add(new Post()
            {
                PetID = 2,
                Description = "Маю колір пінки кави, що бадьорить вас з ранку. Хочу стати таким же радісним промінчиком, як і те горянтко, що бува вип'єш посеред ночі. Я добрий, лігідний і слухняний, і дуже чекаю на  тебе.",
                PublishingTime = new DateTime(2023, 1, 5)
            });
            tmp2.Add(new Post()
            {
                PetID = 3,
                Description =
                            "Так я маю лихий норов і злі очі, але це тому що в мене ще не має дому, забери мене і я буду муркотіти на твоїх колінях",
                PublishingTime = new DateTime(2022, 3, 4)
            });
            tmp2.Add(new Post()
            {
                PetID = 4,
                Description =
                            "Кажуть, чорні коти приносять нещастя, може тому я такий сумний, хоча, мен здається це тому, що я досі не маю дому :( Чи ти не хочеш допомогти мені?",
                PublishingTime = new DateTime(2022, 7, 8)
            });
            tmp2.Add(new Post()
            {
                PetID = 5,
                Description =
                            "Маленьке біленьке янголятко втекло з раю аби знайти тебе, господарю! Знай, що я чекаю на тебе!",
                PublishingTime = new DateTime(2022, 11, 9)
            });
            tmp2.Add(new Post()
            {
                PetID = 6,
                Description =
                            "Я миле маленьке біленьке неподобство, що чекає на тебе. Обіцяю приносити капці зранку, і завжди любити!",
                PublishingTime = new DateTime(2023, 1, 11)
            });
            tmp2.Add(new Post()
            {
                PetID = 7,
                Description =
                            "Готовий стати твоїм другом вже зараз. Не зрозумів, у сенсі ти гортаєш далі???",
                PublishingTime = new DateTime(2023, 1, 5)
            });
            tmp2.Add(new Post()
            {
                PetID = 8,
                Description =
                            "Я прибув з майбутнього, і якщо ти не станеш моїм господарем планета загине!!! Не віриш, глянь мені у вечі, і скажи, що брешу!\n" +
                            "Мовчиш, тож бо і воно, чорно-білі пси, ніколи не брешуть",
                PublishingTime = new DateTime(2023, 1, 11)
            });
            tmp2.Add(new Post()
            {
                PetID = 9,
                Description =
                            "Гортай далі, просто полиш ці сумні оченятка, звісно тобі також непотрібне таке біле неподобство як я?\n Що, що ти готовий бути моїм госпадарем...",
                PublishingTime = new DateTime(2023, 1, 11)
            });
            tmp2.Add(new Post()
            {
                PetID = 10,
                Description =
                            "Я належу до знатного роду, а моє коріння веде ож до королеви Британії. Та не дивлячись на все це я скромний, і тихий собака, що завжди любитиме тебе, і підтримає у складну хвилину Знай, що я чекаю на тебе!",
                PublishingTime = new DateTime(2023, 1, 11)
            });
            foreach (var item in tmp2)
            {
                await App.Database.SavePost(item);
            }
        }
        private void Description_Clicked(object sender, EventArgs e)
        {

            //InitializePetType();
            //InitializePetShelter();
            //InitializePet();
            //InitializePost();

        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePage
            {
                BindingContext = this.BindingContext
            });
        }

        private async void SearchTab_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Search");
            await Navigation.PushAsync(new SearchPage()
            {
                BindingContext = this.BindingContext
            });
        }
    }
}