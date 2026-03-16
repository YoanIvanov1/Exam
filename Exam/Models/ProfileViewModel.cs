namespace Exam.Models
{
    public class ProfileViewModel
    {
        public string Email { get; set; }

        public int WalletBalance { get; set; }

        public List<Bet> Bets { get; set; }
    }
}
