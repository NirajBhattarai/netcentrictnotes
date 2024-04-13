using System;
using Microsoft.AspNetCore.Identity;

namespace BethanysPieShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties specific to your application
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}

