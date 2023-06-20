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

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public void saveNewPie(Pie pie)
        {
            _bethanysPieShopDbContext.Pies.AddRange(pie);
            _bethanysPieShopDbContext.SaveChanges();
        }

        public void update(int pieId)
        {
            var pie = _bethanysPieShopDbContext.Pies.Find(pieId);

            if(pie!=null)
            {
                Pie fetchedPie = pie;
                fetchedPie.ImageUrl = "hello";
            }

            _bethanysPieShopDbContext.SaveChanges();
        }

        public void delete(int pieId)
        {
            var pie = _bethanysPieShopDbContext.Pies.Find(pieId);
            if(pie!=null)
            {
                _bethanysPieShopDbContext.Pies.Remove(pie);
                _bethanysPieShopDbContext.SaveChanges();
            }
        }
    }
}
