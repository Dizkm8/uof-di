using System.ComponentModel.DataAnnotations;

namespace TranslateHistory.Words.Models
{
    public class Word
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Translation { get; set; } = string.Empty;
    }
}