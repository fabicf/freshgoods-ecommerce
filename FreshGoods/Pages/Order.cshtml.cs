using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FreshGoods.Data;
using FreshGoods.Helpers;
using FreshGoods.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Stripe;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using MimeKit;
using MailKit.Net.Smtp;

namespace FreshGoods.Pages
{
    public class OrderModel : PageModel
    {
        private readonly FreshGoodsDbContext db;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<OrderModel> _logger;
        public OrderModel(FreshGoodsDbContext db, SignInManager<ApplicationUser> signInManager,
            ILogger<OrderModel> logger)
        {
            this._signInManager = signInManager;
            this._logger = logger;
            this.db = db;
        }


        public Item Item { get; set; } // new for Item add in order detail
        public List<Item> Items { get; set; } = new List<Item>();
        public List<ItemCart> cart { get; set; }
        public decimal CartTotal { get; set; }

        [BindProperty]
        public Models.Order Order { get; set; }

        [BindProperty]
        public int DeliveryCharge { get; set; }
        [BindProperty]
        public string CardHolderName { get; set; }
        [BindProperty]
        public string CardNo { get; set; }
        [BindProperty]
        public int ExpYear { get; set; }
        [BindProperty]
        public int ExpMonth { get; set; }
        [BindProperty]

        public string CVV { get; set; }
        public bool distance { get; set; }

        public bool delivery = false;
        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<ItemCart>>(HttpContext.Session, "cart");
            CartTotal = cart.Sum(i => i.Item.Price * i.CartQuantity);
            // _logger.LogInformation($"Item in cart is {cart.ToList()} ");
            var userName = User.Identity.Name;
            var user1 = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            string zipCode = user1.ZipCode.Replace(' ', '+');
            DirectionsRequest request = new DirectionsRequest();

            request.Key = "AIzaSyBUrES2BWNC4yFtz9IhYCDRvJF5-6gsJWs";

            request.Origin = new GoogleApi.Entities.Maps.Common.Location(zipCode);
            request.Destination = new GoogleApi.Entities.Maps.Common.Location("H2V+1B1");

            var response = GoogleApi.GoogleMaps.Directions.Query(request);
            if (response.Routes.First().Legs.First().Distance.Value <= 25000)
            {
                distance = true;
            }
            else
            {
                distance = false;
            }

        }
        [Obsolete]
        public IActionResult OnPost()
        {
            var totPrice = Order.TotalPrice;
            var totWithTax = Order.TotalPrice + Order.Tax;
            StripeConfiguration.SetApiKey("sk_test_51IgDsCF8pIUagn4r7OGPpdfl3dXq2BBkssaGcjXsVZCO9kyhuOMVjgUMvr9jSwYyQDg7E7yHXFtBHwt2DphtVMPK0076mFwwzE");
            if (ModelState.IsValid)
            {
                var opttoken = new TokenCreateOptions
                {                    //Card = new CreditCardOptions
                    Card = new TokenCardOptions
                    {
                        Name = CardHolderName,
                        Number = CardNo,
                        ExpYear = ExpYear,
                        ExpMonth = ExpMonth,
                        Cvc = CVV
                    }
                };
                var tokenservice = new TokenService();
                Token stripetoken = tokenservice.Create(opttoken);

                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(Order.FinalPrice * 100),
                    Currency = "cad",
                    Description = "test transactions",
                    Source = stripetoken.Id
                    //SourceId = stripetoken.Id
                };
                //_logger.LogInformation($"option is {options} created 1");
                var service = new ChargeService();
                Charge charge = service.Create(options);
                if (charge.Paid)
                {
                    //DbContextTransaction transaction = db.Database.BeginTransaction();
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var userName = User.Identity.Name;
                            var user1 = db.Users.Where(u => u.UserName == userName).FirstOrDefault();

                            Models.Order order = new Models.Order { Customer = user1, TotalPrice = Order.TotalPrice, Tax = Order.Tax, FinalPrice = Order.FinalPrice, Paid = true, Delivery = delivery };
                            db.Orders.Add(order);
                            db.SaveChanges();
                            _logger.LogInformation($"Data saved in Order table");
                            cart = SessionHelper.GetObjectFromJson<List<ItemCart>>(HttpContext.Session, "cart");
                            foreach (var itemCart1 in cart)
                            {
                                Item = db.Items.FirstOrDefault(m => m.Id == itemCart1.Item.Id);
                                Models.OrderDetail orderDetail = new Models.OrderDetail
                                {
                                    Order = order,
                                    Item = Item,
                                    Quantity = itemCart1.Item.Quantity,
                                    Price = itemCart1.Item.Price
                                };
                                //_logger.LogInformation($"Data save start in ord detail item = {Item},Qty = {itemCart1.Item.Quantity}, price = {itemCart1.Item.Price}");
                                db.OrderDetails.Add(orderDetail);
                                db.SaveChanges();
                            }
                            dbContextTransaction.Commit();
                            MimeMessage message = new MimeMessage();

                            MailboxAddress from = new MailboxAddress("NoReply",
                            "info@freshgoods.com");
                            message.From.Add(from);

                            MailboxAddress to = new MailboxAddress("",
                            Order.Customer.Email);
                            message.To.Add(to);
                            BodyBuilder mailbody = new BodyBuilder();
                            mailbody.HtmlBody = "<p>Your order has been received. Order include(s):</p>";
                            mailbody.HtmlBody += "<Table><tr><th>Name</th><th>Amount</th> <th>Price</th></tr>";
                            for (int i = 0; i < cart.Count; i++)
                            {
                                mailbody.HtmlBody += $"<tr><td>{cart[i].Item.ItemName}</td><td>{cart[i].Item.Quantity}</td><td>{cart[i].Item.Price}</td></tr>";
                            }
                            mailbody.HtmlBody += $"<tr><td></td><td>Total</td><td>{Order.FinalPrice}</td> </tr>";
                            mailbody.HtmlBody += "</Table>";
                            message.Subject = $"Order#{Order.Id} has been received.";
                            message.Body = mailbody.ToMessageBody();
                            SmtpClient client = new SmtpClient();
                            client.Connect("smtp-relay.sendinblue.com", 465, true);
                            client.Authenticate("Kevinparker9908@gmail.com", "W8M9k7GSPApnwr5Q");
                            client.Send(message);
                            client.Disconnect(true);
                            client.Dispose();
                            RedirectToPage("OrderSuccess");
                            Response.WriteAsync("<script>alert('Order submitted succesfully...');</script>");

                        }
                        catch (System.Exception)
                        {
                            dbContextTransaction.Rollback();
                            //throw;
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed on Stripe");
                    Response.WriteAsync("<script>alert('Failed on stripe..');</script>");
                }
            }
            return Page();
        }
    }
}
