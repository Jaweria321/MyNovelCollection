using MyNovelCollection.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNovelCollection
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        static VinyIVaultDatabase database;

        public static VinyIVaultDatabase Database
        {
            get
            {
                string documentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                database = new VinyIVaultDatabase(System.IO.Path.Combine(documentDirectory, "VinyIVaultSQLite.db3"));
                return database;
            }
        }





    }
}
