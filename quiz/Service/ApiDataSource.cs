using System;
using System.Threading.Tasks;
using quiz.Models;
using PhpRunnerService;
using System.Linq;
using System.Collections.Generic;
//using quiz.DTOPhpRunner;

namespace quiz.Service
{
    public class ApiDataSource : IDataStore
    {
        PhpRunnerServiceBase service;
        int GameId = 1;
        string url = "http://pablo.mobi/quiz/";

        public ApiDataSource()
        {
            Settings.ServerApi = url + "api";
            service = new PhpRunnerService.PhpRunnerServiceBase();
        }

        public async Task<List<Card>> GetCards()
        {
            var ask = await service.Search<DTOPhpRunner.Answer>("game_id", PhpRunnerService.Enum.PhpRunnerFilter.Equals, GameId.ToString());
            var answers = await service.Search<DTOPhpRunner.Ask>("game_id", PhpRunnerService.Enum.PhpRunnerFilter.Equals, GameId.ToString());

            //var ask_results = await service.List<DTOPhpRunner.Ask_result>();

            var ask_results = await service.Search<DTOPhpRunner.Ask_result>("game_id", PhpRunnerService.Enum.PhpRunnerFilter.Equals, GameId.ToString());

            var resultDto = await service.Search<DTOPhpRunner.Result>("game_id", PhpRunnerService.Enum.PhpRunnerFilter.Equals, GameId.ToString());
            resultDto = resultDto.OrderBy(x => x.Id).ToList();

            var cards = new List<Card>();
            foreach (var item in ask)
            {
                var tempCard = new Card();
                tempCard.Ask = item.Text;
                tempCard.Answers = new List<Answer>();
                foreach (var itemAnswer in answers)
                {
                    if(itemAnswer.AnswerId == item.Id)
                    {
                        var tempAnswers = new Answer();
                        tempAnswers.Text = itemAnswer.Text;
                        var tempValue = new List<int>();
                        var tempAskResult = ask_results.Where(x => x.AskId == itemAnswer.Id).ToList();
                        foreach (var itemResult in resultDto)
                        {
                            var ar = tempAskResult.Where(x => x.ResultId == itemResult.Id).FirstOrDefault();
                            if(ar == null)
                            {
                                tempValue.Add(0);
                            }
                            else
                            {
                                tempValue.Add(ar.Value);
                            }
                        }
                        tempAnswers.Values = tempValue;
                        tempCard.Answers.Add(tempAnswers);
                    }
                }
                
                cards.Add(tempCard);
            }

            return cards;
        }

        public async Task<Game> GetGame()
        {
            var gameDto = await service.SearchByIds<DTOPhpRunner.Game>(GameId.ToString());
            Game game = new Game();

            if (gameDto.Count > 0)
            {
                game.Name = gameDto.FirstOrDefault().Name;
                game.Logo = url + gameDto.FirstOrDefault().Logo;
                game.Description = gameDto.FirstOrDefault().Description;
            }
            return game;
        }

        public async Task<List<Result>> GetResults()
        {
            var results = new List<Result>();
            var resultDto = await service.Search<DTOPhpRunner.Result>("game_id", PhpRunnerService.Enum.PhpRunnerFilter.Equals, GameId.ToString());
            resultDto = resultDto.OrderBy(x => x.Id).ToList();
            foreach (var item in resultDto)
            {
                results.Add(new Result
                {
                    Name = item.Name,
                    Definitions = item.Definitions,
                    Logo = url + item.Logo
                });
            }
            return results;
        }
    }
}
