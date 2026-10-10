using System.ComponentModel.DataAnnotations;

namespace WordMaster.Models
{
    public class Word
    {
        [Key]
        public int WordId { get; set; }
        public string? Value { get; set; }
    }
}
