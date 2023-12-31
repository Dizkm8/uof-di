using TranslateHistory.Common.Data.Interfaces;
using TranslateHistory.Words.Interfaces;
using TranslateHistory.Words.Models;

namespace TranslateHistory.Words
{
    public class WordsService : IWordsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWordsRepository _wordsRepository;

        public WordsService(IWordsRepository wordsRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _wordsRepository = wordsRepository;
        }

        public List<Word> GetAll()
        {
            return _unitOfWork.WordsRepository.Get().ToList();
        }
    }
}