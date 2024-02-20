using System.ComponentModel.DataAnnotations;

namespace Mission06_Smith.Models
{
    public class MovieCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Category { get; set; }
    }
}
