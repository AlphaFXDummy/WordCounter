using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordCounter.ViewModels;

namespace WordCounter.Services
{
    public class WordCounterService : IWordCounterService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WordCounterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        /// <summary>
        /// Gets top ten words from file based on occurrence 
        /// </summary>
        /// <param name="file">The text file to read from</param>
        /// <returns>Returns a list of top ten words and their occurrences</returns>
        public async Task<WordCounterViewModel> GetTopTenWordsFromTextFile(IFormFile file)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            return await GetWordCounter(file.OpenReadStream());
        }

        /// <summary>
        /// Gets top ten words from url based on occurrence 
        /// </summary>
        /// <param name="url">The url to read from</param>
        /// <returns>Returns a list of top ten words and their occurrences</returns>
        public async Task<WordCounterViewModel> GetTopTenWordsFromUrl(string url)
        {
            if (url is null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            var client = _httpClientFactory.CreateClient();
            return await GetWordCounter(await client.GetStreamAsync(new Uri(url)));
        }

        private async Task<WordCounterViewModel> GetWordCounter(Stream stream)
        {
            List<Word> words = new List<Word>();
            using (var sr = new StreamReader(stream))
            {
                while (sr.Peek() >= 0)
                {
                    var line = await sr.ReadLineAsync();
                    MatchCollection matches = Regex.Matches(line, @"\b[\w']*\b");
                    foreach (Match match in matches)
                    {
                        if (!(match.Value == string.Empty || long.TryParse(match.Value, out _)))
                        {
                            var word = words.FirstOrDefault(x => x.name == match.Value.ToLower());
                            if (word is null)
                            {
                                words.Add(new Word()
                                {
                                    name = match.Value.ToLower(),
                                    Occurrence = 1
                                });
                            }
                            else
                            {
                                word.Occurrence++;
                            }
                        }
                    }
                }
            }
            return new WordCounterViewModel()
            {
                TopTenWords = words.OrderByDescending(x => x.Occurrence).Take(10).ToList()
            };
        }


    }
}
