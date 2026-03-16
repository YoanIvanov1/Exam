using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Region { get; set; }

        [Range(1, 12)]
        public int Ranking { get; set; }
    }
}
