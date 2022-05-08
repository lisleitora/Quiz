using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quiz.Models;
using Xamarin.Forms;

namespace quiz.Pages
{
    public partial class QuizPage : ContentPage

    {
        bool isBusy;
        
        List<Card> cards;
        List<Result> results;
        int index = 0;

        public QuizPage(List<Card> _cards, List<Result> _results)
        {
            InitializeComponent();

            cards = _cards;
            results = _results;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PageChanger();
        }

        async void ButtonView_Left(System.Object sender, System.EventArgs e)
        {
            if (isBusy)
            {
                return;
            }
            if (index==0)
            {
                return;
            }
            isBusy = true;
            index = index - 1;
            PageChanger();
           // await ButtonLeft.ScaleTo(1.4, 100);
          
           //await ButtonLeft.ScaleTo(0.5, 180);
           // ButtonLeft.ScaleTo(1, 170);

        }

       async void ButtonView_Right(System.Object sender, System.EventArgs e)
        {
            if (isBusy)
            {
                return;
            }
            if (index == cards.Count-1 || !cards[index].IsAnswered)
            {
                return;
            }
            isBusy = true;
            index = index + 1;
            PageChanger();
            //await ButtonRight.ScaleTo(1.4, 100);

            //await ButtonRight.ScaleTo(0.5, 180);
            //ButtonRight.ScaleTo(1, 170);
        }

       async void PageChanger()
        {
            if (index == 0)
            {
                ButtonLeft.Opacity = .2;
            }
            else
            {
                ButtonLeft.Opacity = 1;
            }
            if (index == cards.Count-1 || !cards[index].IsAnswered)
            {
                ButtonRight.Opacity = .2;
            }
            else
            {
                ButtonRight.Opacity = 1;
            }
            AnswersStack.Children.Clear();
            AskLabel.Text = cards[index].Ask;
            AskFrame.Opacity = 0;
            AskFrame.Scale = 0.5;
            NumberBar.Text = index + 1 + "/" + cards.Count;

            //Fb.ScaleXTo(.5, 700, Easing.BounceOut);
            Fb.WidthRequest = (index + 1)* Tb.Width / cards.Count;
            foreach (var item in cards[index].Answers)
            {
                var temp = new Views.ButtonView()
                {
                    Text = item.Text,
                    CallBack = new Command(() => OnResult(item.Values))
                };

                AnswersStack.Children.Add(temp);
                temp.Opacity = 0;
                temp.Scale = 0.3;
            }
            await Task.Delay(200);
            AskFrame.FadeTo(1, 700);
            await AskFrame.ScaleTo(1, 800, Easing.SpringOut);
            await Task.Delay(200);

            foreach (var temp in AnswersStack.Children)
            {
                temp.Opacity = 0;
                temp.Scale = 0.3;
                temp.FadeTo(1, 200);
                await temp.ScaleTo(1.2, 200);
                temp.ScaleTo(1, 200);
            }
            isBusy = false;
        }

        void OnResult(List<int> values)
        {
            if (isBusy)
            {
                return;
            }
            cards[index].IsAnswered = true;
            isBusy = true;
            var i = 0;
            foreach (var item in results)
            {
                if(i < values.Count)
                item.Value += values[i];
                i++;
            }
            if (index == cards.Count - 1)
            {
                App.Current.MainPage = new Pages.EndPage(results);
                isBusy = false;
            }
            else
            {
                index = index + 1;
                PageChanger();
            }
        }

    }
}
