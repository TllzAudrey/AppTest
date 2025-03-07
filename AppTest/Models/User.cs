using Microsoft.AspNetCore.Identity;

namespace AppTest.Models
{
    public class User : IdentityUser
    {
        public string? nom { get; set; }
        public string? prenom { get; set; }

    }
}
