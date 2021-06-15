using System.Collections.Generic;
using System.Linq;
using FreshGoods.Data;
using FreshGoods.Models;

namespace FreshGoods.Models
{
    public class ProductModel
    {
        public List<Item>  Items {get;set;} = new List<Item>();
        public readonly FreshGoodsDbContext db;  
        public ProductModel(FreshGoodsDbContext db) => this.db = db;
        
        public List<Item> findAll(){
            Items = db.Items.ToList();
            return Items;
        }

        public Item find(int id){
            Items = db.Items.ToList();
            return Items.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}