using Microsoft.AspNetCore.Identity;

namespace Exam.Models
{
    public class User : IdentityUser
    {
        public int WalletBalance { get; set; } = 5000;
    }
}
