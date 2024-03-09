using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _bethanysPieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _bethanysPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public void AddPie(Pie pie)
        {
            pie.CategoryId = 1;
            _bethanysPieShopDbContext.Pies.Add(pie);
            _bethanysPieShopDbContext.SaveChanges();
        }

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public void UpdatePie(Pie pie)
        {
            var existingPie = _bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pie.PieId);
            if (existingPie == null)
            {
                throw new ArgumentException("Pie not found");
            }

            existingPie.Name = pie.Name;
            existingPie.Price = pie.Price;
            existingPie.ShortDescription = pie.ShortDescription;
            existingPie.LongDescription = pie.LongDescription;
            existingPie.InStock = pie.InStock;
            existingPie.ImageUrl = pie.ImageUrl;
            existingPie.ImageThumbnailUrl = pie.ImageThumbnailUrl;
            existingPie.IsPieOfTheWeek = pie.IsPieOfTheWeek;

            _bethanysPieShopDbContext.Entry(existingPie).State = EntityState.Modified;
            _bethanysPieShopDbContext.SaveChanges();
        }
    }
}