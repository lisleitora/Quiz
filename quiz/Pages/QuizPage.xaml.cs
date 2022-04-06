using System;
using System.Collections.Generic;
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
       
        void ButtonView_Left(System.Object sender, System.EventArgs e)
        {
            if (index==0)
            {
                return;
            }
            index = index - 1; 
            PageChanger();
        }

        void ButtonView_Right(System.Object sender, System.EventArgs e)
        {
            if (index == cards.Count-1)
            {
                return;
            }
            index = index + 1;
            PageChanger();
        }

        void PageChanger()
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
            AskLabel.Text = cards[index].Ask;
            NumberBar.Text = index + 1 + "/" + cards.Count;
            AnswersStack.Children.Clear();
            foreach (var item in cards[index].Answers)
            {
                AnswersStack.Children.Add(new Views.ButtonView() {
                    Text = item.Text,
                    CallBack = new Command(() => OnResult(item.Values))
                });
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
