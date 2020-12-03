using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordCounter.ViewModels
{
    public class WordCounterViewModel
    {
        public List<Word> TopTenWords { get; set; }
    }
        
    public class Word
    {
        public string name { get; set; }
        public int Occurrence { get; set; }
    }
}
