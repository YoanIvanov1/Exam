namespace Exam.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int MatchId { get; set; }

        public string Team { get; set; }

        public int Amount { get; set; }

        public DateTime PlacedAt { get; set; }
    }
}
