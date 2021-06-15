using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FreshGoods.Models;
using FreshGoods.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshGoods.Pages
{
    public class BuyItemModel : PageModel
    {
        private readonly FreshGoodsDbContext db;  
        public BuyItemModel(FreshGoodsDbContext db) => this.db = db;
       
        public List<Item> Items ;
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            //ProductModel prodModel = new ProductModel();
            //Items = prodModel.findAll();
            Items = db.Items.ToList();
        }


    }
}
