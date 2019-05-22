using AppLocator.Bootstrap;
using AppLocator.Database;
using AppLocator.Models.Messages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppLocator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.RegisterDependenies();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MasterDetailPageView();
        }

        private static StoreDatabase database;

        public static StoreDatabase DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new StoreDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "AppLocatorSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            var message = new StopFindStoreOffersTask();
            MessagingCenter.Send(message, "StopFindStoreOffersTask");

            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            var message = new StartFindStoreOffersTask();
            MessagingCenter.Send(message, "StartFindStoreOffersTask");
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            var message = new StopFindStoreOffersTask();
            MessagingCenter.Send(message, "StopFindStoreOffersTask");

            // Handle when your app resumes
        }
    }
}
