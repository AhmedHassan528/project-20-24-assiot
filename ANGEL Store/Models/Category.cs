using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ANGEL.Models
{
    [Table("Category", Schema = "dbo")]

    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


    }
}
