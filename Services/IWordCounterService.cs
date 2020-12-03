using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.ViewModels;

namespace WordCounter.Services
{
    public interface IWordCounterService
    {
        Task<WordCounterViewModel> GetTopTenWordsFromTextFile(IFormFile file);
        Task<WordCounterViewModel> GetTopTenWordsFromUrl(string Url);

    }
}
