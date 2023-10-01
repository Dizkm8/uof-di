using Microsoft.AspNetCore.Mvc;
using TranslateHistory.Common;
using TranslateHistory.Common.Data.Interfaces;
using TranslateHistory.Words.Models;

namespace TranslateHistory.Words
{
    public class WordsController : GenericController
    {
        private readonly IUnitOfWork _uof;

        public WordsController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<List<Word>>> AllWords()
        {
            var result = await _uof.WordsRepository.Get(null, null, "");
            return result;
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            await _uof.WordsRepository.Delete("a");
            return Ok("Deleted");
        }
    }
}