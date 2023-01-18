using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Coffee.Data;
using Coffee.Pages;
using System.Collections.Generic;
using Coffee.Models;

namespace Coffee
{
    public partial class App : Application
    {
        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
