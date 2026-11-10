using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Bet
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [Required]
        public int MatchId { get; set; }

        public Match Match { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string Team { get; set; } = null!;

        [Range(1, 5000)]
        public int Amount { get; set; }

        public DateTime PlacedAt { get; set; }
    }
}
