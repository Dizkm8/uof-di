using TranslateHistory.Words.Models;

namespace TranslateHistory.Words.Interfaces
{
    public interface IWordsService
    {
        public List<Word> GetAll();
    }
}