using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Services;
using WordCounter.ViewModels;

namespace WordCounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordCounterController : ControllerBase
    {
        private readonly IWordCounterService _wordCounterService;

        public WordCounterController(IWordCounterService wordCounterService)
        {
            _wordCounterService = wordCounterService ?? throw new ArgumentNullException(nameof(wordCounterService));
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm]UploadFileViewModel vm)
        {
            try
            {
                var wordCounterViewModel = await _wordCounterService.GetTopTenWordsFromTextFile(vm.File);
                return Ok(wordCounterViewModel);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("GetWordCountByUrl")]
        public async Task<IActionResult> GetWordCountByUrl(string url)
        {
            try
            {
                var wordCounterViewModel = await _wordCounterService.GetTopTenWordsFromUrl(url);
                return Ok(wordCounterViewModel);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }
    }
}
