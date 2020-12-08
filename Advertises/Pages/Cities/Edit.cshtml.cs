using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Cities
{
    public class EditModel : PageModel
    {

        private IBaseService<City> _cityService;

        public EditModel(IBaseService<City> cityService)
        {
            _cityService = cityService;
        }

       
        [BindProperty]
        public City MyCity
        { set; get; }


        public void OnGet(long id)
        {
            //MyCity = _context.Cities.FirstOrDefault(x => x.Id == id);
            MyCity = _cityService.Get(id);
        }
        public void Onpost()
        {
            //var tt = _context.Cities.FirstOrDefault(x => x.Id == MyCity.Id);
            //tt.Name = MyCity.Name;

            //_context.Cities.Update(tt);
            //_context.SaveChanges();
            var tt = _cityService.Get(MyCity.Id);
            tt.Name = MyCity.Name;

            _cityService.Update(tt);
          
        }
    }
}