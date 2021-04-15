using TST.CORE.Extensions;
using TST.CORE.Helpers;
using TST.ENTITIES.Base.Implementations;
using TST.ENTITIES.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKDEMIC.ENTITIES.Models.Generals
{
    public class ApplicationUser : IdentityUserEntity, IKeyNumber, ISoftDelete, ITimestamp
    {
        public Guid? DepartmentId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? ProvinceId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        [MaxLength(250)]
        public string Dni { get; set; }
        public string FullName { get; set; } // = $"{(String.IsNullOrEmpty(PaternalSurname) ? "" : $"{PaternalSurname} ")}{(String.IsNullOrEmpty(MaternalSurname) ? "" : $"{MaternalSurname}")}, {(String.IsNullOrEmpty(Name) ? "" : $"{Name}")}";
      
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string MaternalSurname { get; set; }

        [MaxLength(250)]
        public string PaternalSurname { get; set; }
        public string PersonalEmail { get; set; }

        [Required]
        public int Sex { get; set; } = 1;

        [NotMapped]
        public int Age => BirthDate > DateTime.Today.AddYears(-(DateTime.Today.Year - BirthDate.Year)) ? (DateTime.Today.Year - BirthDate.Year - 1) : DateTime.Today.Year - BirthDate.Year;

        [NotMapped]
        public string BirthDateString => BirthDate.ToLocalDateFormat();

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
