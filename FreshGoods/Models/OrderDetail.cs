using System.ComponentModel.DataAnnotations;

namespace FreshGoods.Models
{
    public class OrderDetail
    {
        public int Id{get;set;}
        [Required]
        public Order Order{get;set;}
        [Required]
        public Item Item{get;set;}
        
        [Required]
        public decimal Quantity{get;set;}
        [Required]
        public decimal Price{get;set;}
    }
}