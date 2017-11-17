using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LicencePlateFinder.Repositories;
using LicencePlateFinder.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicencePlateFinder.Controllers
{
    public class Licence_plateController : Controller
    {
        Licence_plateRepository licence_plateRepository;

        public Licence_plateController(Licence_plateRepository licence_plateRepository)
        {
            this.licence_plateRepository = licence_plateRepository;
        }

        [Route("")]
        [Route("/search")]
        [HttpGet]
        public IActionResult Index([FromQuery] string q)
        {
            var cars = new List<Licence_plate>();
            cars = licence_plateRepository.GetCars(q);
            return View(cars);
        }
    }
}
