using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string TeamA { get; set; }

        [Required]
        [StringLength(10)]
        public string TeamB { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(50)]
        public string Location { get; set; }
    }
}
