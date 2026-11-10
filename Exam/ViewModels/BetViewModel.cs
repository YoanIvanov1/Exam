namespace Exam.ViewModels
{
    public class BetViewModel
    {
        public int Id { get; set; }

        public string MatchTitle { get; set; } = null!;

        public DateTime MatchDate { get; set; }

        public string Team { get; set; } = null!;

        public int Amount { get; set; }

        public DateTime PlacedAt { get; set; }
    }
}
