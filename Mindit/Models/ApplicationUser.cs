using Microsoft.AspNetCore.Identity;

namespace Mindit.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatarString { get; set; }

        public string GetAvatarString()
        {
            return AvatarString;
        }
    }
}
