using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FreshGoods.Data;
using FreshGoods.Models;
using System.Text;
using Microsoft.Extensions.Logging;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Authorization;

namespace FreshGoods.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin,Worker")]
    public class DetailsModel : PageModel
    {
        private readonly FreshGoods.Data.FreshGoodsDbContext _context;
        private readonly ILogger<DetailsModel> _logger;
        public DetailsModel(FreshGoods.Data.FreshGoodsDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        [BindProperty]
        public IList<OrderDetail> OrderDetails { get; set; }
        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders.Include(m => m.Customer).FirstOrDefaultAsync(m => m.Id == id);
            OrderDetails = await _context.OrderDetails.Include(m => m.Item).Where(m => m.Order.Id == id).ToListAsync();

            if (OrderDetails == null|| Order.perpared)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            int id = Order.Id;
            Order = await _context.Orders.Include(m => m.Customer).FirstOrDefaultAsync(m => m.Id == id);
            OrderDetails = await _context.OrderDetails.Include(m => m.Item).Where(m => m.Order.Id == id).ToListAsync();
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("NoReply",
            "info@freshgoods.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("",
            Order.Customer.Email);
            message.To.Add(to);
            BodyBuilder mailbody = new BodyBuilder();
            if (Order.Delivery)
            {
                message.Subject = "Delivery is on its way.";
                mailbody.HtmlBody = "<p>Your order has been perpared and is head out for delivery. Delivery include(s):</p>";
            }
            else
            {

                mailbody.HtmlBody = "<p>Your order has been perpared and is Ready for Pick up. Order include(s):</p>";
            }
            mailbody.HtmlBody += "<Table><tr><th>Name</th><th>Amount</th> <th>Price</th></tr>";
            for (int i = 0; i < OrderDetails.Count; i++)
            {
                mailbody.HtmlBody += $"<tr><td>{OrderDetails[i].Item.ItemName}</td><td>{OrderDetails[i].Quantity}</td><td>{OrderDetails[i].Price}</td></tr>";
            }
            mailbody.HtmlBody += $"<tr><td></td><td>Total</td><td>{Order.FinalPrice}</td> </tr>";
            mailbody.HtmlBody += "</Table>";
            message.Subject = $"Order#{Order.Id} has been prepared.";
            message.Body = mailbody.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp-relay.sendinblue.com", 465, true);
            client.Authenticate("Kevinparker9908@gmail.com", "W8M9k7GSPApnwr5Q");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            Order.perpared = true;
            _context.Attach(Order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Success");
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
