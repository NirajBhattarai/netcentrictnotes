using System;
namespace BethanysPieShop.ViewModels
{
    public class AddPieViewModel
    {

        public string Name { get; set; }


        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public int CategoryId { get; set; }

        public bool InStock { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsPieOfTheWeek { get; set; }

    }
}

