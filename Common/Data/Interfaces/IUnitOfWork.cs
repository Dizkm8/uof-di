using TranslateHistory.Words;

namespace TranslateHistory.Common.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        public WordsRepository WordsRepository { get; }
    }
}