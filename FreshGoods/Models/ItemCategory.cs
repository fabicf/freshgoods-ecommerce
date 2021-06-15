using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshGoods.Models
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

                   
        public string Slug { get; set; }

    }
}
