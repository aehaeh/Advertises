using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises
{
    public class AddLocalModel : PageModel
    {
        public List<SelectListItem> ListCities { get; set; } = new List<SelectListItem>();
        private ApplicationDbContext _context;

        public AddLocalModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Local MyLocal
        {
            set;
            get;
        }

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
            var cities = _context.Cities.ToList();
            PopulateCityDropDownList(cities, null);
        }
        public void Onpost()
        {
            MyLocal.CreateDate = DateTime.Now;
            _context.Locations.Add(MyLocal);
            _context.SaveChanges();
        }
    }
}