using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SalesAPI.Entities
{
    public class Role : IdentityRole
    {
        [MaxLength(250)]
        public string Description { get; set; } = null!;
    }
}
