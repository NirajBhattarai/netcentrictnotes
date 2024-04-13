using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BethanysPieShop.ViewModels
{
    public class LoginViewModel
    {

        public string? Email { get; set; }


        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }

}

