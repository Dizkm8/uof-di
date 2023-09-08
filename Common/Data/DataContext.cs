using Microsoft.EntityFrameworkCore;
using TranslateHistory.Words.Models;

namespace TranslateHistory.Common.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Word> Words { get; set; } = null!;
    }
}