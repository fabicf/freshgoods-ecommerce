using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreshGoods.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Address1 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address2 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Province = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    ImageFileName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<string>(type: "TEXT", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tax = table.Column<decimal>(type: "TEXT", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Paid = table.Column<bool>(type: "INTEGER", nullable: false),
                    Delivery = table.Column<bool>(type: "INTEGER", nullable: false),
                    perpared = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "CategoryName", "Slug" },
                values: new object[] { 4, "Bakery", "bakery" });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "CategoryName", "Slug" },
                values: new object[] { 1, "Fruits", "fruits" });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "CategoryName", "Slug" },
                values: new object[] { 3, "Vegetables", "vegetables" });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "CategoryName", "Slug" },
                values: new object[] { 2, "Meat", "meat" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 64, 4, "bakt-16.jpeg", "Multi Baguette", 3.19m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 36, 3, "veg-03.jpeg", "Cherry Tomato", 3.29m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 37, 3, "veg-04.jpeg", "Acorn Squash", 3.69m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 38, 3, "veg-05.jpeg", "Broccoli", 2.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 39, 3, "veg-06.jpeg", "Curly Lettuce", 3.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 40, 3, "veg-07.jpeg", "Aspargus", 2.29m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 41, 3, "veg-08.jpeg", "Mini Eggplant", 3.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 42, 3, "veg-09.jpeg", "Pumpkin", 5.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 43, 3, "veg-10.jpeg", "Farm Carrots", 5.89m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 44, 3, "veg-11.jpeg", "Green Pepper", 2.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 45, 3, "veg-1.jpeg", "Sweet Pepers", 7.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 46, 3, "veg-13.jpeg", "White Onion", 2.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 47, 3, "veg-14.jpeg", "Sweet Corn", 3.29m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 48, 3, "veg-15.jpeg", "Arugula", 3.49m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 49, 3, "veg-16.jpeg", "Red Pepper", 3.19m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 35, 3, "veg-02.jpeg", "Fresh Cabbage", 3.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 52, 4, "bakt-04.jpeg", "Nut Butter Snack", 3.69m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 53, 4, "bakt-05.jpeg", "Loaf Bread", 2.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 54, 4, "bakt-06.jpeg", "Milk Loaf", 3.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 55, 4, "bakt-07.jpeg", "Choco Croissant", 2.29m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 56, 4, "bakt-08.jpeg", "Mini Chicken Pie", 6.99m, 1, "Dozen" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 57, 4, "bakt-09.jpeg", "Mini Muffin", 5.49m, 1, "Dozen" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 58, 4, "bakt-10.jpeg", "Choco Cookies", 1.89m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 59, 4, "bakt-11.jpeg", "Croissant", 2.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 60, 4, "bakt-12.jpeg", "Honey Muffin", 1.59m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 61, 4, "bakt-13.jpeg", "White Baguette", 3.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 62, 4, "bakt-14.jpeg", "Wheat Bread", 5.29m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 63, 4, "bakt-15.jpeg", "Multi Bread", 4.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 50, 4, "bakt-02.jpeg", "Polish Load", 3.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 51, 4, "bakt-03.jpeg", "Cinnamon Roll ", 1.29m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 34, 2, "meat-16.jpeg", "Spicy Sausage", 21.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 32, 2, "meat-14.jpeg", "Spicy Bacon", 15.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 2, 2, "meat-1.jpeg", "Beef Ossobuco", 15.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 3, 3, "veg-12.jpeg", "Mix Peppers", 4.99m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 4, 4, "bakt-1.jpeg", "Sourdough Bread", 7.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 5, 1, "fruit-1.jpeg", "Wild Orange", 3.99m, 1, "Dozen" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 6, 1, "fruit-03.jpeg", "Papaya Mex", 3.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 7, 1, "fruit-04.jpeg", "Hass Avocado", 5.69m, 1, "Dozen" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 8, 1, "fruit-05.jpeg", "Fiji Cocunut", 3.29m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 9, 1, "fruit-06.jpeg", "Concord Grape", 4.49m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 10, 1, "fruit-07.jpeg", "Red Cherry", 5.29m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 11, 1, "fruit-08.jpeg", "Gala Apple", 3.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 12, 1, "fruit-09.jpeg", "Red strawberry", 3.49m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 13, 1, "fruit-10.jpeg", "Wild Blackberry", 5.99m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 14, 1, "fruit-11.jpeg", "Green Kiwi", 2.49m, 1, "Dozen" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 15, 1, "fruit-12.jpeg", "Musk Melon", 2.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 33, 2, "meat-15.jpeg", "Veal Ossobuco", 13.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 16, 1, "fruit-13.jpeg", "Golden Pineapple", 3.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 18, 1, "fruit-15.jpeg", "Semillon Grape", 3.49m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 19, 1, "fruit-16.jpeg", "Cavendish Banana", 1.49m, 1, "Pack" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 20, 2, "meat-02.jpeg", "Pork Ribeye", 11.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 21, 2, "meat-03.jpeg", "Smoked Bacon", 13.29m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 22, 2, "meat-04.jpeg", "Dry Aged Bacon", 25.69m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 23, 2, "meat-05.jpeg", "Pork Belly", 9.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 24, 2, "meat-06.jpeg", "Seasoned Pork", 14.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 25, 2, "meat-07.jpeg", "Pork Shoulder", 10.29m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 26, 2, "meat-08.jpeg", "Cured Sausage", 13.99m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 27, 2, "meat-09.jpeg", "Picanha Sirloin", 11.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 28, 2, "meat-10.jpeg", "Italian Sausage", 15.89m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 29, 2, "meat-11.jpeg", "Ribeye Steak", 22.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 30, 2, "meat-12.jpeg", "Veal Skewer", 2.99m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 31, 2, "meat-13.jpeg", "German Sausage", 23.49m, 1, "Kg" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 17, 1, "fruit-14.jpeg", "Watermelon", 5.49m, 1, "Unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "ImageFileName", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[] { 1, 1, "fruit-02.jpeg", "Dragon Fruit", 3.59m, 1, "Unit" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
