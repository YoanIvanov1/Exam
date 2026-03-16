using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class ProfileViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int WalletBalance { get; set; }

        public List<Bet> Bets { get; set; }
    }
}
