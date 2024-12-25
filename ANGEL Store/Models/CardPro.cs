using ANGEL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANGEL_Store.Models
{
    [Table("CardPro", Schema = "dbo")]

    public class CardPro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        public string UserId { get; set; }



        //[ForeignKey("Item")]
        //public int? ItemID { get; set; }






        [Display(Name = "Item Name")]
        [Required]
        public string ItemName { get; set; }

        [Display(Name = "Item price")]
        [Required]
        public decimal ItemPrice { get; set; }

        [Display(Name = "Item Image")]
        public string? ItemImage { get; set; }
        


        [Display(Name = "Item Color")]
        [Required]
        public string SelectedColor { get; set; }

        [NotMapped]
        public decimal? ItemTotal { get; set; }


        [Display(Name = "Item Quantity")]
        [Required]
        public int QTY { get; set; }

        [Display(Name = "Item Size")]
        [Required]
        public string SelectedSize { get; set; }

        [NotMapped]
        public string[] paymentMethod { get; set; } = { "cash on delivery"};

        [Display(Name = "Payment Method")]
        public string? SelectedPaymentMethod { get; set; }

        // for custom item


        [NotMapped]
        public int SelectedLocationId { get; set; }

        public virtual Item? item { get; set; }




    }
}
