using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FreshGoods.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string Province { get; set; }
        [Required]
        [StringLength(7)]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$")]
        public string ZipCode { get; set; }
        
    }
}