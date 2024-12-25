using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ANGEL_Store.Models
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(255)]
        [Display(Name = "First Name ")]
        public string firstName { get; set; }

        [Required, MaxLength(255)]
        [Display(Name = "Last Name ")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string? PhoneNum { get; set; }
    }
}
