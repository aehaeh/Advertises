using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises
{
    public class AddLocalModel : PageModel
    {
        public List<SelectListItem> ListCities { get; set; } = new List<SelectListItem>();
        private IBaseService<Local> _localService;
        private IBaseService<City> _cityService;

        public AddLocalModel(IBaseService<Local> localService, IBaseService<City> cityService)
        {
            _localService = localService;
            _cityService = cityService;
        }

        [BindProperty]
        public LocalViewModel MyLocal
        { set; get; }

        public void PopulateCityDropDownList(IList<City> cities,
           List<long> selectedCity)
        {
            var cityQuery = from d in cities
                            orderby d.Name // Sort by name.
                            select d;

            ListCities = cityQuery.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            }).ToList();
        }
        public void OnGet()
        {
            var cities = _cityService.GetAll().ToList();
            PopulateCityDropDownList(cities, null);
        }
        public IActionResult Onpost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            MyLocal.CreateDate = DateTime.Now;



            Local persistLocal = new Local();
            persistLocal.Advertisements = MyLocal.Advertisements;
            persistLocal.City = MyLocal.City;
            persistLocal.CityId = MyLocal.CityId;
            persistLocal.CreateDate = MyLocal.CreateDate;
            persistLocal.Id = MyLocal.Id;
            persistLocal.IsActive = MyLocal.IsActive;
            persistLocal.Name = MyLocal.Name;
            persistLocal.UpdatedDate = MyLocal.UpdatedDate;
            
            _localService.Insert(persistLocal);

            return Page();

        }
    }
}