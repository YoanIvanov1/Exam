using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels
{
    public class BetFormViewModel
    {
        public int Id { get; set; }

        public int MatchId { get; set; }

        public string TeamA { get; set; } = null!;

        public string TeamB { get; set; } = null!;

        [Required(ErrorMessage = "Please choose a team.")]
        [StringLength(10)]
        public string Team { get; set; } = null!;

        [Required(ErrorMessage = "Please enter an amount.")]
        [Range(1, 5000, ErrorMessage = "The amount must be between {1} and {2} tokens.")]
        [Display(Name = "Amount (tokens)")]
        public int Amount { get; set; }
    }
}
