using FreshGoods.Models;
using Microsoft.EntityFrameworkCore;
namespace FreshGoods.Data
{
    public static class ModelBuilderExtensions
    {
        private static ItemCategory fruits;
        private static ItemCategory meat;
        private static ItemCategory vegetables;
        private static ItemCategory bakery;

        public static ModelBuilder Seed(this ModelBuilder modelBuilder){
            modelBuilder.Entity<ItemCategory>().HasData(
                fruits = new ItemCategory
                {
                    Id = 1,
                    CategoryName = "Fruits",
                    Slug = "fruits"                   
                },
                meat = new ItemCategory
                {
                    Id = 2,
                    CategoryName = "Meat",
                    Slug = "meat"                            
                },
                vegetables = new ItemCategory
                {
                    Id = 3,
                    CategoryName = "Vegetables",
                    Slug = "vegetables"                            
                },
                bakery = new ItemCategory
                {
                    Id = 4,
                    CategoryName = "Bakery",
                    Slug = "bakery"                            
                }
            );

             modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    ItemName = "Dragon Fruit",
                    CategoryId = fruits.Id,
                    Price = 3.59m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "fruit-02.jpeg"
                },
                
                new Item
                {
                    Id = 2,
                    ItemName = "Beef Ossobuco",
                    CategoryId = meat.Id,
                    Price = 15.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-1.jpeg"
                },
                new Item
                {
                    Id = 3,
                    ItemName = "Mix Peppers",
                    CategoryId = vegetables.Id,
                    Price = 4.99m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "veg-12.jpeg"
                },
                new Item
                {
                    Id = 4,
                    ItemName = "Sourdough Bread",
                    CategoryId = bakery.Id,
                    Price = 7.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-1.jpeg"
                },

                // ------------------ Fruits -------------------
                new Item
                {
                    Id = 5,
                    ItemName = "Wild Orange",
                    CategoryId = fruits.Id,
                    Price = 3.99m,
                    Quantity = 1,
                    Unit = "Dozen",
                    ImagePath = "fruit-1.jpeg"
                },
                new Item
                {
                    Id = 6,
                    ItemName = "Papaya Mex",
                    CategoryId = fruits.Id,
                    Price = 3.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "fruit-03.jpeg"
                },
                new Item
                {
                    Id = 7,
                    ItemName = "Hass Avocado",
                    CategoryId = fruits.Id,
                    Price = 5.69m,
                    Quantity = 1,
                    Unit = "Dozen",
                    ImagePath = "fruit-04.jpeg"
                },
                new Item
                {
                    Id = 8,
                    ItemName = "Fiji Cocunut",
                    CategoryId = fruits.Id,
                    Price = 3.29m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "fruit-05.jpeg"
                },
                 new Item
                {
                    Id = 9,
                    ItemName = "Concord Grape",
                    CategoryId = fruits.Id,
                    Price = 4.49m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "fruit-06.jpeg"
                },
                 new Item
                {
                    Id = 10,
                    ItemName = "Red Cherry",
                    CategoryId = fruits.Id,
                    Price = 5.29m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "fruit-07.jpeg"
                },                 
                 new Item
                {
                    Id = 11,
                    ItemName = "Gala Apple",
                    CategoryId = fruits.Id,
                    Price = 3.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "fruit-08.jpeg"
                },
                new Item
                {
                    Id = 12,
                    ItemName = "Red strawberry",
                    CategoryId = fruits.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "fruit-09.jpeg"
                },
                 new Item
                {
                    Id = 13,
                    ItemName = "Wild Blackberry",
                    CategoryId = fruits.Id,
                    Price = 5.99m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "fruit-10.jpeg"
                },
                 new Item
                {
                    Id = 14,
                    ItemName = "Green Kiwi",
                    CategoryId = fruits.Id,
                    Price = 2.49m,
                    Quantity = 1,
                    Unit = "Dozen",
                    ImagePath = "fruit-11.jpeg"
                },
                 new Item
                {
                    Id = 15,
                    ItemName = "Musk Melon",
                    CategoryId = fruits.Id,
                    Price = 2.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "fruit-12.jpeg"
                },
                 new Item
                {
                    Id = 16,
                    ItemName = "Golden Pineapple",
                    CategoryId = fruits.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "fruit-13.jpeg"
                },
                 new Item
                {
                    Id = 17,
                    ItemName = "Watermelon",
                    CategoryId = fruits.Id,
                    Price = 5.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "fruit-14.jpeg"
                },
                 new Item
                {
                    Id = 18,
                    ItemName = "Semillon Grape",
                    CategoryId = fruits.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "fruit-15.jpeg"
                },
                 new Item
                {
                    Id = 19,
                    ItemName = "Cavendish Banana",
                    CategoryId = fruits.Id,
                    Price = 1.49m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "fruit-16.jpeg"
                }, 

                 // ------------------ Meat -------------------
                new Item
                {
                    Id = 20,
                    ItemName = "Pork Ribeye",
                    CategoryId = meat.Id,
                    Price = 11.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-02.jpeg"
                },
                new Item
                {
                    Id = 21,
                    ItemName = "Smoked Bacon",
                    CategoryId = meat.Id,
                    Price = 13.29m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-03.jpeg"
                },
                new Item
                {
                    Id = 22,
                    ItemName = "Dry Aged Bacon",
                    CategoryId = meat.Id,
                    Price = 25.69m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-04.jpeg"
                },
                new Item
                {
                    Id = 23,
                    ItemName = "Pork Belly",
                    CategoryId = meat.Id,
                    Price = 9.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-05.jpeg"
                },
                 new Item
                {
                    Id = 24,
                    ItemName = "Seasoned Pork",
                    CategoryId = meat.Id,
                    Price = 14.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-06.jpeg"
                },
                 new Item
                {
                    Id = 25,
                    ItemName = "Pork Shoulder",
                    CategoryId = meat.Id,
                    Price = 10.29m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-07.jpeg"
                },                 
                 new Item
                {
                    Id = 26,
                    ItemName = "Cured Sausage",
                    CategoryId = meat.Id,
                    Price = 13.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-08.jpeg"
                },
                new Item
                {
                    Id = 27,
                    ItemName = "Picanha Sirloin",
                    CategoryId = meat.Id,
                    Price = 11.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-09.jpeg"
                },
                 new Item
                {
                    Id = 28,
                    ItemName = "Italian Sausage",
                    CategoryId = meat.Id,
                    Price = 15.89m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-10.jpeg"
                },
                 new Item
                {
                    Id = 29,
                    ItemName = "Ribeye Steak",
                    CategoryId = meat.Id,
                    Price = 22.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-11.jpeg"
                },
                 new Item
                {
                    Id = 30,
                    ItemName = "Veal Skewer",
                    CategoryId = meat.Id,
                    Price = 2.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "meat-12.jpeg"
                },
                 new Item
                {
                    Id = 31,
                    ItemName = "German Sausage",
                    CategoryId = meat.Id,
                    Price = 23.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-13.jpeg"
                },
                 new Item
                {
                    Id = 32,
                    ItemName = "Spicy Bacon",
                    CategoryId = meat.Id,
                    Price = 15.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-14.jpeg"
                },
                 new Item
                {
                    Id = 33,
                    ItemName = "Veal Ossobuco",
                    CategoryId = meat.Id,
                    Price = 13.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-15.jpeg"
                },
                 new Item
                {
                    Id = 34,
                    ItemName = "Spicy Sausage",
                    CategoryId = meat.Id,
                    Price = 21.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "meat-16.jpeg"
                },   

                 // ------------------ Vegetables -------------------
                new Item
                {
                    Id = 35,
                    ItemName = "Fresh Cabbage",
                    CategoryId = vegetables.Id,
                    Price = 3.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "veg-02.jpeg"
                },
                new Item
                {
                    Id = 36,
                    ItemName = "Cherry Tomato",
                    CategoryId = vegetables.Id,
                    Price = 3.29m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-03.jpeg"
                },
                new Item
                {
                    Id = 37,
                    ItemName = "Acorn Squash",
                    CategoryId = vegetables.Id,
                    Price = 3.69m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "veg-04.jpeg"
                },
                new Item
                {
                    Id = 38,
                    ItemName = "Broccoli",
                    CategoryId = vegetables.Id,
                    Price = 2.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-05.jpeg"
                },
                 new Item
                {
                    Id = 39,
                    ItemName = "Curly Lettuce",
                    CategoryId = vegetables.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "veg-06.jpeg"
                },
                 new Item
                {
                    Id = 40,
                    ItemName = "Aspargus",
                    CategoryId = vegetables.Id,
                    Price = 2.29m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "veg-07.jpeg"
                },                 
                 new Item
                {
                    Id = 41,
                    ItemName = "Mini Eggplant",
                    CategoryId = vegetables.Id,
                    Price = 3.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-08.jpeg"
                },
                new Item
                {
                    Id = 42,
                    ItemName = "Pumpkin",
                    CategoryId = vegetables.Id,
                    Price = 5.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-09.jpeg"
                },
                 new Item
                {
                    Id = 43,
                    ItemName = "Farm Carrots",
                    CategoryId = vegetables.Id,
                    Price = 5.89m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "veg-10.jpeg"
                },
                 new Item
                {
                    Id = 44,
                    ItemName = "Green Pepper",
                    CategoryId = vegetables.Id,
                    Price = 2.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-11.jpeg"
                },
                 new Item
                {
                    Id = 45,
                    ItemName = "Sweet Pepers",
                    CategoryId = vegetables.Id,
                    Price = 7.99m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-1.jpeg"
                },
                 new Item
                {
                    Id = 46,
                    ItemName = "White Onion",
                    CategoryId = vegetables.Id,
                    Price = 2.49m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-13.jpeg"
                },
                 new Item
                {
                    Id = 47,
                    ItemName = "Sweet Corn",
                    CategoryId = vegetables.Id,
                    Price = 3.29m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-14.jpeg"
                },
                 new Item
                {
                    Id = 48,
                    ItemName = "Arugula",
                    CategoryId = vegetables.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Pack",
                    ImagePath = "veg-15.jpeg"
                },
                 new Item
                {
                    Id = 49,
                    ItemName = "Red Pepper",
                    CategoryId = vegetables.Id,
                    Price = 3.19m,
                    Quantity = 1,
                    Unit = "Kg",
                    ImagePath = "veg-16.jpeg"
                },

                 // ------------------ Bakery -------------------
                new Item
                {
                    Id = 50,
                    ItemName = "Polish Load",
                    CategoryId = bakery.Id,
                    Price = 3.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-02.jpeg"
                },
                new Item
                {
                    Id = 51,
                    ItemName = "Cinnamon Roll ",
                    CategoryId = bakery.Id,
                    Price = 1.29m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-03.jpeg"
                },
                new Item
                {
                    Id = 52,
                    ItemName = "Nut Butter Snack",
                    CategoryId = bakery.Id,
                    Price = 3.69m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-04.jpeg"
                },
                new Item
                {
                    Id = 53,
                    ItemName = "Loaf Bread",
                    CategoryId = bakery.Id,
                    Price = 2.99m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-05.jpeg"
                },
                 new Item
                {
                    Id = 54,
                    ItemName = "Milk Loaf",
                    CategoryId = bakery.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-06.jpeg"
                },
                 new Item
                {
                    Id = 55,
                    ItemName = "Choco Croissant",
                    CategoryId = bakery.Id,
                    Price = 2.29m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-07.jpeg"
                },                 
                 new Item
                {
                    Id = 56,
                    ItemName = "Mini Chicken Pie",
                    CategoryId = bakery.Id,
                    Price = 6.99m,
                    Quantity = 1,
                    Unit = "Dozen",
                    ImagePath = "bakt-08.jpeg"
                },
                new Item
                {
                    Id = 57,
                    ItemName = "Mini Muffin",
                    CategoryId = bakery.Id,
                    Price = 5.49m,
                    Quantity = 1,
                    Unit = "Dozen",
                    ImagePath = "bakt-09.jpeg"
                },
                 new Item
                {
                    Id = 58,
                    ItemName = "Choco Cookies",
                    CategoryId = bakery.Id,
                    Price = 1.89m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-10.jpeg"
                },
                 new Item
                {
                    Id = 59,
                    ItemName = "Croissant",
                    CategoryId = bakery.Id,
                    Price = 2.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-11.jpeg"
                },
                 new Item
                {
                    Id = 60,
                    ItemName = "Honey Muffin",
                    CategoryId = bakery.Id,
                    Price = 1.59m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-12.jpeg"
                },
                 new Item
                {
                    Id = 61,
                    ItemName = "White Baguette",
                    CategoryId = bakery.Id,
                    Price = 3.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-13.jpeg"
                },
                 new Item
                {
                    Id = 62,
                    ItemName = "Wheat Bread",
                    CategoryId = bakery.Id,
                    Price = 5.29m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-14.jpeg"
                },
                 new Item
                {
                    Id = 63,
                    ItemName = "Multi Bread",
                    CategoryId = bakery.Id,
                    Price = 4.49m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-15.jpeg"
                },
                 new Item
                {
                    Id = 64,
                    ItemName = "Multi Baguette",
                    CategoryId = bakery.Id,
                    Price = 3.19m,
                    Quantity = 1,
                    Unit = "Unit",
                    ImagePath = "bakt-16.jpeg"
                }   

            );
            return modelBuilder;
        }
    }
}