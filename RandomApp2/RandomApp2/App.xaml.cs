using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomApp2
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App(string _databasePath)
        {
            InitializeComponent();
            DatabasePath = _databasePath;

            MainPage = new NavigationPage(new MainPage());
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
    }
}
