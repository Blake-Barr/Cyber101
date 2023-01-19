using Microsoft.AspNetCore.Identity;

namespace WatchfulEye.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
