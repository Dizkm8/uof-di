using Microsoft.AspNetCore.Mvc;
using TranslateHistory.Common;
using TranslateHistory.Words.Interfaces;

namespace TranslateHistory.Words
{
    public class WordsController : GenericController
    {
        private readonly IWordsService _wordsService;

        public WordsController(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        [HttpGet]
        public async Task<ActionResult> AllWords()
        {
            return Ok(new
            {
                words = _wordsService.GetAll()
            });
        }
    }
}