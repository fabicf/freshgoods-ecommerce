using System.ComponentModel.DataAnnotations;

namespace FreshGoods.Models
{
    public class Order
    {
        public int Id{get;set;}

         //[Required]
        public ApplicationUser Customer{get;set;}
        //public ApplicationUser UserId{get;set;}

        [Required]
        public decimal TotalPrice{get;set;}
        [Required]
        public decimal Tax{get;set;}
        [Required]
        public decimal FinalPrice{get; set;}
        [Required]
        public bool Paid{get; set;}
        [Required]
        public bool Delivery{get;set;}

        public bool perpared{get; set;}
    }
}