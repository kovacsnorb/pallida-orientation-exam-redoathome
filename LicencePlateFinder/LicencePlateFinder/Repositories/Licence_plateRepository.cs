using LicencePlateFinder.Entities;
using LicencePlateFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicencePlateFinder.Repositories
{
    public class Licence_plateRepository
    {
        Licence_plateContext licence_PlateContext;

        public Licence_plateRepository(Licence_plateContext licence_PlateContext)
        {
            this.licence_PlateContext = licence_PlateContext;
        }

        public List<Licence_plate> GetCars(string plateSearch)
        {
            return licence_PlateContext.Licence_plates.Where(p => p.Plate.Contains(plateSearch)).ToList();
        }

        public List<Licence_plate> GetPoliceCars(int policeNumber)
        {
            return licence_PlateContext.Licence_plates.Where(p => p.Plate.StartsWith("RB")).ToList();
        }

        public List<Licence_plate> GetDiplomatCars(int diplomatNumber)
        {
            return licence_PlateContext.Licence_plates.Where(p => p.Plate.StartsWith("DT")).ToList();
        }

        public List<Licence_plate> GetBrand(string brand)
        {
            return licence_PlateContext.Licence_plates.Where(p => p.Car_brand == brand).ToList();
        }
    }
}
