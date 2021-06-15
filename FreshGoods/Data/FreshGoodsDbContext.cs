using FreshGoods.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FreshGoods.Data
{
    //public class FreshGoodsDbContext : DbContext
    //public class FreshGoodsDbContext : IdentityDbContext
    public class FreshGoodsDbContext : IdentityDbContext<ApplicationUser>
    {
        public FreshGoodsDbContext (DbContextOptions<FreshGoodsDbContext> options)
            : base(options)
            {

            } 
        //public DbSet<User> Users { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Order> Orders{get; set;}
        public DbSet<OrderDetail> OrderDetails{get; set;}
        public DbSet<Promotion> Promotions{get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=FreshGoods.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new FriendConfiguration()).Seed();
            modelBuilder.ApplyConfiguration(new ItemConfiguration()).Seed();
            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // On event model creating
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}