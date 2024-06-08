using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SalesAPI.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(250)]
        [Required]
        public string FirstName { get; set; } = null!;
        [MaxLength(250)]
        [Required]
        public string LastName { get; set; } = null!;
    }
}
