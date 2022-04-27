using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quiz.Models;
using Xamarin.Forms;

namespace quiz.Pages
{
    public partial class QuizPage : ContentPage
    {
        List<Card> cards;
        List<Result> results;
        int index = 0;

        public QuizPage()
        {
            InitializeComponent();

            results = new List<Result>();
            results.Add(new Result { Name = "Grifindor", Value = 0,Definitions="texto4",Logo = "logogrifindor2.png" });
            results.Add(new Result { Name = "Slytherin", Value = 0,Definitions="texto3", Logo = "logoslytherin.png" });
            results.Add(new Result { Name = "Hufflepuff", Value = 0, Definitions ="texto2", Logo = "logohufflepuff.png" });
            results.Add(new Result { Name = "Ravenclaw", Value = 0, Definitions ="texto1", Logo = "logoravenclaw.png" });

            cards = new List<Card>();
            cards.Add(new Card {
                Ask="Se você achar um dinheiro no chão, você...",
                Answers = new List<Answer>()
                {
                    new Answer
                    {
                        Text = "Tentaria achar o dono !",
                        Values = new List<int>{10,0,0,0}
                    },
                    new Answer
                    {
                        Text = "Tentaria pegar ele bem disfarçadamente.",
                        Values = new List<int>{0,10,0,0}
                    },
                    new Answer
                    {
                        Text = "Compraria um monte de doçes",
                        Values = new List<int>{0,0,10,0}
                    },
                    new Answer
                    {
                        Text = "Compraria um bom livro",
                        Values = new List<int>{0,0,0,10}
                    }
                }
            });
            cards.Add(new Card
            {
                Ask = "Se aparecesse um leão na sua frente",
                Answers = new List<Answer>()
                {
                    new Answer
                    {
                        Text = "Abraçaria ele com força",
                        Values = new List<int>{10,0,0,0}
                    },
                    new Answer
                    {
                        Text = "Correria como um louco",
                        Values = new List<int>{0,10,0,0}
                    },
                    new Answer
                    {
                        Text = "Ainnnnn que fofo",
                        Values = new List<int>{0,0,10,0}
                    },
                    new Answer
                    {
                        Text = "Iria procurar outro lugar para ler um livro",
                        Values = new List<int>{0,0,0,10}
                    }
                }
            });
            cards.Add(new Card
            {
                Ask = "O que você faria com um livro ?",
                Answers = new List<Answer>()
                {
                   new Answer
                    {
                        Text = "Montaria uma partida bem engraçada",
                        Values = new List<int>{10,0,0,0}
                    },
                    new Answer
                    {
                        Text = "Bom para colocar no pé de uma mesa",
                        Values = new List<int>{0,10,0,0}
                    },
                    new Answer
                    {
                        Text = "Tem figuras ?",
                        Values = new List<int>{0,0,10,0}
                    },
                    new Answer
                    {
                        Text = "Livros eu amo livros.",
                        Values = new List<int>{0,0,0,10}
                    }
                }
            });
            PageChanger();
        }
       
       async void ButtonView_Left(System.Object sender, System.EventArgs e)
        {
            if (index==0)
            {
                return;
            }
            index = index - 1;
            PageChanger();
           // await ButtonLeft.ScaleTo(1.4, 100);
          
           //await ButtonLeft.ScaleTo(0.5, 180);
           // ButtonLeft.ScaleTo(1, 170);
        }

       async void ButtonView_Right(System.Object sender, System.EventArgs e)
        {
            if (index == cards.Count-1)
            {
                return;
            }
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
            if (index == cards.Count-1)
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
        }

        void OnResult(List<int> values)
        {
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
            }
            else
            {
                index = index + 1;
                PageChanger();
            }
        }

    }
}
