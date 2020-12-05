using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class AddModel : PageModel
    {
        private IBaseService<City> _cityService;

        public AddModel(IBaseService<City> cityService)
        {
            _cityService = cityService;
        }

        [BindProperty]
        public City MyCity
        {
            set;
            get;
        }

        public void OnGet()
        {

        }
        public void Onpost()
        {
            MyCity.CreateDate = DateTime.Now;
            //_context.Cities.Add(MyCity);
            //_context.SaveChanges();
            _cityService.Insert(MyCity);
        }
    }
}