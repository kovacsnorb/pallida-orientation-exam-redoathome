using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LicencePlateFinder.Repositories;
using LicencePlateFinder.Models;
using System.Text.RegularExpressions;

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
        public IActionResult Index([FromQuery] string q, int police, int diplomat)
        {
            Regex regexObj = new Regex("^[a-zA-Z0-9-]+$", RegexOptions.Multiline);

            var cars = new List<Licence_plate>();
            if (q != null && regexObj.Match(q).Success && q.Length <= 7)
            {
                cars = licence_plateRepository.GetCars(q);
                return View(cars);
            }
            else if (police == 1)
            {
                cars = licence_plateRepository.GetPoliceCars(police);
                return View(cars);
            }
            else if (diplomat == 1)
            {
                cars = licence_plateRepository.GetDiplomatCars(police);
                return View(cars);
            }
            else
            {
                return View(cars);
            }
        }

        [Route("/search/{brand}")]
        [HttpGet]
        public IActionResult Index([FromRoute] string brand)
        {
            var cars = new List<Licence_plate>();
            if (brand != null)
            {
                cars = licence_plateRepository.GetBrand(brand);
                return View(cars);
            }
            else
            {
                return View(cars);
            }
        }

        [Route("/api/search/{brand}")]
        [HttpGet]
        public IActionResult ApiBrand([FromRoute] string brand)
        {
            var cars = new List<Licence_plate>();
            if (brand != null)
            {
                cars = licence_plateRepository.GetBrand(brand);
                return Json(cars);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
