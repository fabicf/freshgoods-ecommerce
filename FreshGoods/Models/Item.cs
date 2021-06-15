using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshGoods.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // TODO: Map CategoryId 
        public ItemCategory Category;

        // [RegularExpression(@"^\d+\.\d{0,3}$", ErrorMessage = "Please enter currency format 999.99")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        public string Unit { get; set; }


        public string ImagePath { get; set; }
    }
}
