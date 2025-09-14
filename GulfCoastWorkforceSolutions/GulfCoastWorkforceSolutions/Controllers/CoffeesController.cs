using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Kentico.Content.Web.Mvc.Routing;
using Kentico.Content.Web.Mvc;

using GulfCoastWorkforceSolutions;
using GulfCoastWorkforceSolutions.Controllers;
using GulfCoastWorkforceSolutions.Models.Coffees;
using GulfCoastWorkforceSolutions.Models.Products;
using GulfCoastWorkforceSolutions.Repositories;
using GulfCoastWorkforceSolutions.Repositories.Filters;
using GulfCoastWorkforceSolutions.Services;

[assembly: RegisterPageRoute("GulfCoastWorkforceSolutionsMvc.ProductSection", typeof(CoffeesController), Path = ContentItemIdentifiers.COFFEES)]

namespace GulfCoastWorkforceSolutions.Controllers
{
    public class CoffeesController : Controller
    {
        private readonly ICoffeeRepository coffeeRepository;
        private readonly ICalculationService calculationService;
        private readonly IPageUrlRetriever pageUrlRetriever;


        public CoffeesController(ICoffeeRepository coffeeRepository, ICalculationService calculationService, IPageUrlRetriever pageUrlRetriever)
        {
            this.coffeeRepository = coffeeRepository;
            this.calculationService = calculationService;
            this.pageUrlRetriever = pageUrlRetriever;
        }


        // GET: Coffees
        public ActionResult Index()
        {
            var items = GetFilteredCoffees(null);
            var filter = new CoffeeFilterViewModel();
            filter.Load();

            return View(new ProductListViewModel
            {
                Filter = filter,
                Items = items
            });
        }


        // POST: Filter
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Coffees/Filter")]
        public ActionResult Filter(CoffeeFilterViewModel filter)
        {
            if (!Request.IsAjaxRequest())
            {
                return HttpNotFound();
            }
               
            var items = GetFilteredCoffees(filter);

            return PartialView("CoffeeList", items);
        }


        private IEnumerable<ProductListItemViewModel> GetFilteredCoffees(IRepositoryFilter filter)
        {
            var coffees = coffeeRepository.GetCoffees(filter);
           
            var items = coffees.Select(
                coffee => new ProductListItemViewModel(
                    coffee,
                    calculationService.CalculatePrice(coffee.SKU),
                    coffee.Product.PublicStatus?.PublicStatusDisplayName,
                    pageUrlRetriever)
                );
            return items;
        }
    }
}