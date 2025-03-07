using Microsoft.AspNetCore.Identity;

namespace AppTest.Models
{
    public class User : IdentityUser
    {
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? mail { get; set; }
        public string? mdp { get; set; }

    }
}
