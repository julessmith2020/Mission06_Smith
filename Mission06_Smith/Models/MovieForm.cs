using System.ComponentModel.DataAnnotations;

namespace Mission06_Smith.Models
{
    public class MovieForm
    {
        [Key]
        public int MovieID { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters")]
        public string Notes { get; set; }
    }
}
