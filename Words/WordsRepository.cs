using TranslateHistory.Common.Data;
using TranslateHistory.Common.Data.Interfaces;
using TranslateHistory.Words.Interfaces;
using TranslateHistory.Words.Models;

namespace TranslateHistory.Words
{
    public class WordsRepository : GenericRepository<Word>, IWordsRepository
    {
        public WordsRepository(DataContext context) : base(context)
        {
        }
    }
}