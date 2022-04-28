using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace quiz.Pages
{
    public partial class StartPage : ContentPage
    {

        bool isBusy;
		
		public StartPage()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1,1000);
        }

       

      async void OnClicked(object sender, EventArgs args)
        {
            if (isBusy)
            {
                return;
            }
            isBusy = true;
            StartButton.FadeTo(0, 500);
            await DesText.FadeTo(0, 500);
            await StartText.FadeTo(0, 500);
            await StartLogo.FadeTo(0, 800);
            App.Current.MainPage = new Pages.QuizPage();
            isBusy = false;
        }
    }
}
