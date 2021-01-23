using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymWebApplication1.Models
{
    public class Membership : BaseEntity
    {
        public int MembershipId { get; set; }
        [Required]
        [Display(Name = "UserName")]
        [StringLength(20, ErrorMessage = "Name is too long")]
        public string MembershipName { get; set; }
        public string MembershipLastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [Range(18, 70, ErrorMessage = "Please enter between 18 to 70 ")]
        public int MembershipAge { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter Valid email")]
        public string MEmail { get; set; }
        public string PackageType { get; set; }
        public ICollection<Bill> Bills { get; set; }

    }
}
