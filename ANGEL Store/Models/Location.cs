using ANGEL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANGEL_Store.Models
{
    [Table("Location", Schema = "dbo")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }


        public string UserId { get; set; }


        [Required (ErrorMessage = "Please enter your Street")]
        public string Street { get; set; }


        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }



        [Required(ErrorMessage = "Please enter your State")]
        public string State{ get; set; }



        [Required(ErrorMessage = "Please enter correct State")]
        [Display(Name = "First phoneNumber")]
        [MaxLength(11, ErrorMessage = "Please enter correct phoneNumber")]
        [MinLength(11, ErrorMessage = "Please enter correct phoneNumber")]

        public string phoneNumber { get; set; }




        [Display(Name = "Second phoneNumber (optional)")]
        [MaxLength(11, ErrorMessage = "Please enter correct phoneNumber")]
        [MinLength(11, ErrorMessage = "Please enter correct phoneNumber")]
        public string? SecPhoneNumber { get; set; }



        [Required]
        [Display(Name = "First Address")]
        public string Address1 { get; set; }



        [Display(Name = "Second Address (optional)")]
        public string? Address2 { get; set; }



    }
}
