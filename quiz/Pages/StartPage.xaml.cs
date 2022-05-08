using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using quiz.Models;

namespace quiz.Pages
{
    public partial class StartPage : ContentPage
    {

        bool isBusy;
        List<Card> cards;
        List<Result> results;

        public StartPage()
        {
            InitializeComponent();
            content.Opacity = 0;
            loading.IsVisible = true;
        }

        protected async override void OnAppearing()
        {
            content.Opacity = 0;
            loading.IsVisible = true;

            base.OnAppearing();
            
            await Task.Delay(500);
            var game = await App.DataStore.GetGame();
            StartText.Text = game.Name;
            DesText.Text = game.Description;
            StartLogo.Source = game.Logo;
            loading.IsVisible = false;
            results = await App.DataStore.GetResults();
            cards = await App.DataStore.GetCards();
            await content.FadeTo(1,1000);
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
            App.Current.MainPage = new Pages.QuizPage(cards, results);
            isBusy = false;
        }
    }
}
