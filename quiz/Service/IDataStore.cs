using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using quiz.Models;

namespace quiz.Service
{
    public interface IDataStore
    {
        Task<Game> GetGame();
        Task<List<Result>> GetResults();
        Task<List<Card>> GetCards();
    }
}