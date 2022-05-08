using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quiz.Models;
using Xamarin.Forms;

namespace quiz.Pages
{
    public partial class EndPage : ContentPage
    {
        bool isBusy;

        List<Result> results;

        public EndPage(List<Result> _results)
        {
            results = _results;
            InitializeComponent();
            results = results.OrderByDescending(x => x.Value).ToList();
            var result = results.FirstOrDefault();
            LogoImage.Source = result.Logo;
            //TitleLabel.Text = item.Name +" - "+ item.Value.ToString();
            TitleLabel.Text = result.Name;
            DefinitionLabel.Text = result.Definitions;
            LogoImage.Opacity = 0;
            DefinitionLabel.Opacity = 0;
            TitleLabel.Opacity = 0;
            BackButton.Opacity = 0;
            LogoImage.Scale = .2;
            

        }

      async protected override void OnAppearing()
        {
            base.OnAppearing();
             LogoImage.ScaleTo(1, 1000, Easing.SpringOut);
            await LogoImage.FadeTo(1, 500);
            
            await TitleLabel.FadeTo(1, 500);
            await DefinitionLabel.FadeTo(1, 500);
            await BackButton.FadeTo(1, 800);
            allResult.Children.Clear();
            var rTotal = results.Sum(x => x.Value);
            foreach (var item in results)
            {
                var rPor = (item.Value * 100 / rTotal)  + "%";
                var line = new Views.ItemResultView(item.Name, rPor);
                allResult.Children.Add(line);
            }
        }
        async void ButtonView_Clicked(System.Object sender, System.EventArgs e)
        {
            if (isBusy)
            {
                return;

            }
            isBusy = true;
             BackButton.FadeTo(0, 500);
             ShareButton.FadeTo(0, 500);
            await DefinitionLabel.FadeTo(0, 500);
            await TitleLabel.FadeTo(0, 500);
            await LogoImage.FadeTo(0, 800);
            App.Current.MainPage = new Pages.StartPage();
            isBusy = false;
        }
    }
}
