using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.ViewModels
{
	public class UpdatePieViewModel
	{      
            public int PieId { get; set; }

            
            public string Name { get; set; }

            public decimal Price { get; set; }

            public string ShortDescription { get; set; }

            public string LongDescription { get; set; }

            public bool InStock { get; set; }

            public string ImageUrl { get; set; }

            public string ImageThumbnailUrl { get; set; }

            public bool IsPieOfTheWeek { get; set; }

            
            public int CategoryId { get; set; }
        
    }
}

