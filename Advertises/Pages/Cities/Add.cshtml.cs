using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
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
        public CityViewModel MyCity
        { set; get; }

        public void OnGet()
        {

        }
        public void Onpost()
        {
            MyCity.CreateDate = DateTime.Now;
            MyCity.IsActive = false;
            //_context.Cities.Add(MyCity);
            //_context.SaveChanges();
            //_cityService.Insert(MyCity);

            City persistCity = new City();
            persistCity.Id = MyCity.Id;
            persistCity.Locals = MyCity.Locals;
            persistCity.Name = MyCity.Name;
            persistCity.UpdatedDate = MyCity.UpdatedDate;
            persistCity.CreateDate = MyCity.CreateDate;
            persistCity.IsActive = MyCity.IsActive;
            _cityService.Insert(persistCity);

        }
    }
}