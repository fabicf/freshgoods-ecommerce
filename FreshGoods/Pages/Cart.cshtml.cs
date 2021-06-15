using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using FreshGoods.Helpers;
using FreshGoods.Models;
using FreshGoods.Data;
using Microsoft.AspNetCore.Authorization;

namespace FreshGoods.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly FreshGoodsDbContext db;  
        public CartModel(FreshGoodsDbContext db) => this.db = db;
        public List<Item>  Items {get;set;} = new List<Item>();
        public List<ItemCart> cart {get; set;}
        public decimal Total {get; set;}
        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<ItemCart>>(HttpContext.Session,"cart");
            Total = cart.Sum(i => i.Item.Price * i.CartQuantity);    
        }
        
        public IActionResult OnGetBuyNow(int id){
           // var prodModal = new ProductModel();
            cart = SessionHelper.GetObjectFromJson<List<ItemCart>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<ItemCart>();
                cart.Add(new ItemCart
                {
                    //Item = prodModal.find(id),
                    Item = find(id),
                    CartQuantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new ItemCart
                    {
                        //Item = prodModal.find(id),
                        Item = this.find(id),
                        CartQuantity = 1
                    });
                }
                else
                {
                    cart[index].CartQuantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }
    public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<ItemCart>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<ItemCart>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].CartQuantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        private int Exists(List<ItemCart> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Item.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    
        public Item find(int id){
            Items = db.Items.ToList();
            return Items.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
