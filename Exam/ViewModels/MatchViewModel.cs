namespace Exam.ViewModels
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        public string TeamA { get; set; } = null!;

        public string TeamB { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Location { get; set; } = null!;
    }
}
