using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quiz.Models;

namespace quiz.Service
{
    public class MockDataStore : IDataStore
    {
        public async Task<List<Card>> GetCards()
        {
            
            var cards = new List<Card>();
            cards.Add(new Card
            {
                Ask = "Se você achar um dinheiro no chão, você...",
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
            return await Task.FromResult(cards);
        }

        public async Task<Game> GetGame()
        {
            var game = new Game
            {
                Logo = "logo.png",
                Name = "Name of Game",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation"
            };
            return await Task.FromResult(game);
        }

        public async Task<List<Result>> GetResults()
        {
            var results = new List<Result>();
            results.Add(new Result { Name = "Grifindor", Value = 0, Definitions = "texto4", Logo = "logogrifindor2.png" });
            results.Add(new Result { Name = "Slytherin", Value = 0, Definitions = "texto3", Logo = "logoslytherin.png" });
            results.Add(new Result { Name = "Hufflepuff", Value = 0, Definitions = "texto2", Logo = "logohufflepuff.png" });
            results.Add(new Result { Name = "Ravenclaw", Value = 0, Definitions = "texto1", Logo = "logoravenclaw.png" });
            return await Task.FromResult(results);
        }
    }
}
