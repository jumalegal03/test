using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AKDEMIC.ENTITIES.Models.Generals;
using Microsoft.AspNetCore.Identity;

namespace TST.ENTITIES.Models.Generals
{
    public class ApplicationRole : IdentityRole
    {
        public int Priority { get; set; }

        [NotMapped]
        public bool IsInProcedure { get; set; }

        public bool IsStatic { get; set; } = false;
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
