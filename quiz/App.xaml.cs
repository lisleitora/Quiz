using System;
using quiz.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace quiz
{
    public partial class App : Application
    {
        public static IDataStore DataStore => DependencyService.Get<IDataStore>();

        public App()
        {
            InitializeComponent();
           // DependencyService.Register<MockDataStore>();
            DependencyService.Register<ApiDataSource>();

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
