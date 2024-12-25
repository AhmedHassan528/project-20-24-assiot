using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANGEL.Models
{
    [Table("Item", Schema = "dbo")]

    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        

        [Required]
        [Display(Name = "Item Tag")]
        public string ItemTag { get; set; }
        public List<String>? Taglist { get; set; }


        [Required]
        [Display(Name = "Item Information")]
        public string ItemInformation { get; set; }
        public List<String>? Informationlist { get; set; }



        [Required]
        [StringLength(255)]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }




        [Required]
        [Display(Name = "Item Price")]
        public decimal ItemPrice { get; set; }



        public List<String>? Sizelist { get; set; }
        [Required]
        [Display(Name = "Item Size")]
        public string Size { get; set; }
        public string? SelectedSize { get; set; }



        public List<String>? Colorlist { get; set; }

        [Required]
        [Display(Name = "Item Color")]
        public String Color { get; set; }
        public string? SelectedColor { get; set; }



        [Display(Name = "Item Image")]
        public string? ItemImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }



        [Display(Name = "Number of products in store")]
        public int? NumOfProducts { get; set; }


        [Required]
        [Display(Name = "Item Quantity")]
        public int ItemQuantity { get; set; }

        [Required]
        [Display(Name = "Item Status")]
        public bool ItemStatus { get; set; }

        [Display(Name = "Item Discount")]
        public decimal? ItemDiscount { get; set; }






        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Category Name")]
        [NotMapped]
        public string? CategoryName { get; set; }


        public virtual Category? category { get; set; }

    }
}
