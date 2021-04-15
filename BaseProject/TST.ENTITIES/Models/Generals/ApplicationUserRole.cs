using Microsoft.AspNetCore.Identity;
using TST.ENTITIES.Models.Generals;

namespace AKDEMIC.ENTITIES.Models.Generals
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
