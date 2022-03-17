using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace quiz
{
    public partial class App : Application
    {
        public App()
        {
            //App.Current.UserAppTheme = OSAppTheme.Dark;
            InitializeComponent();

            MainPage = new Pages.StartPage();
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
