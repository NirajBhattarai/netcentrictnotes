﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BethanysPieShop.ViewModels
{
    public class RegisterViewModel
    {
        public string? Email { get; set; }


        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }


        public string? FirstName { get; set; }


        public string? LastName { get; set; }
    }

}

