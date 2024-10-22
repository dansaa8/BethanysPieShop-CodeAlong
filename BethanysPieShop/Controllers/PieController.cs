using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    // kan kallas med Pie(utan Controller).
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        // Använder Dependency Injection; de som vi la till som services i program.cs.
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this._pieRepository = pieRepository;
            this._categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            // Views kommer åt props som läggs till i ViewBag
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(pieRepository.AllPies);
            PieListViewModel pieListViewModel = new PieListViewModel
                (_pieRepository.AllPies, "Cheese cakes");
            return View(pieListViewModel);
        }
    }
}
