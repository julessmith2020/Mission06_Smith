using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Smith.Models
{
    public class MovieForm
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public MovieCategory? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888")]
        public int Year { get; set; }
        public string? Director { get; set; }

        [Required(ErrorMessage ="Rating is required")]
        public string? Rating { get; set; }

        [Required(ErrorMessage ="Edited field is required")]
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public bool? CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters")]
        public string? Notes { get; set; }
    }
}
