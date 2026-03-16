using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class User : IdentityUser
    {
        [Range(0, 999999)]
        public int WalletBalance { get; set; } = 5000;
    }
}
