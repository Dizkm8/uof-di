using TranslateHistory.Common.Data.Interfaces;
using TranslateHistory.Words;

namespace TranslateHistory.Common.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext _context;
        private WordsRepository wordsRepository = null!;
        private bool _disposed = false;

        public UnitOfWork(DataContext context)
        {

            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public WordsRepository WordsRepository
        {
            get
            {
                wordsRepository ??= new WordsRepository(_context);
                return wordsRepository;
            }
        }
    }
}