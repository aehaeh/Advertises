using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises
{
    public class IndexCitiesModel : PageModel
    {

       
        private IBaseService<City> _cityService;

        public IndexCitiesModel(IBaseService<City> cityService)
        {
            _cityService = cityService;
        }

       
        [BindProperty]
        public IList<City> Cities
        { set; get; }
        public DbSet<Advertisement> Advertisementlist { get; private set; }

        public void OnGet()
        {
            //Cities = _context.Cities.ToList();
            Cities = _cityService.GetAll().ToList();
        }
    }
}