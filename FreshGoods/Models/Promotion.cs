using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace FreshGoods.Models
{
    public class Promotion
    {
        public int Id{get;set;}
        [Required]
        public int ItemId{get;set;}
        [Required]
        public bool Type {get;set;}
        [Required]
        public DateTime StartDate {get;set;}
        [Required]
        public DateTime EndDate {get;set;}
    }
}