using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {

            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }

        public ActionResult AddPie()
        {

            var viewModel = new AddPieViewModel();

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPie(AddPieViewModel model)
        {

            Pie newPie = new Pie
            {
                Name = model.Name,
                Price = model.Price,
                ShortDescription = model.ShortDescription,
                LongDescription = model.LongDescription,
                CategoryId = model.CategoryId,
                //Category = category,
                InStock = model.InStock,
                ImageUrl = model.ImageUrl,
                ImageThumbnailUrl = model.ImageThumbnailUrl,
                IsPieOfTheWeek = model.IsPieOfTheWeek
            };
            _pieRepository.AddPie(newPie);
            return RedirectToAction("List");
        }

        public ActionResult EditPie(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            

            var editPieViewModel = new UpdatePieViewModel
            {
                PieId = pie.PieId,
                Name = pie.Name,
                Price = pie.Price,
                ShortDescription = pie.ShortDescription,
                LongDescription = pie.LongDescription,
                CategoryId = pie.CategoryId,
                InStock = pie.InStock,
                ImageUrl = pie.ImageUrl,
                ImageThumbnailUrl = pie.ImageThumbnailUrl,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
            };

            return View(editPieViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPie(UpdatePieViewModel model)
        {
            
                var pie = _pieRepository.GetPieById(model.PieId);
                

                pie.Name = model.Name;
                pie.Price = model.Price;
                pie.ShortDescription = model.ShortDescription;
                pie.LongDescription = model.LongDescription;
                pie.InStock = model.InStock;
                pie.ImageUrl = model.ImageUrl;
                pie.ImageThumbnailUrl = model.ImageThumbnailUrl;
                pie.IsPieOfTheWeek = model.IsPieOfTheWeek;

                _pieRepository.UpdatePie(pie);

                return RedirectToAction("List");

            // Reload categories if model state is invalid to repopulate the dropdown
  
        }


    }

}
