using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Bet
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        [StringLength(10)]
        public string Team { get; set; }

        [Range(1, 5000)]
        public int Amount { get; set; }

        public DateTime PlacedAt { get; set; }
    }
}
