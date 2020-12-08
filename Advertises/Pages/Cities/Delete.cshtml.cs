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
    public class DeleteModel : PageModel
    {
        private IBaseService<City> _cityService;

        public DeleteModel(IBaseService<City> cityService)
        {
            _cityService = cityService;
           
        }

       
        [BindProperty]
        public City MyCity
        { set; get; }

        public void OnGet(long id)
        {
            //MyCity = _context.Cities.SingleOrDefault(m => m.Id == id);
            MyCity = _cityService.Get(id);
        }
        public void OnPost()
        {
           
            if (MyCity != null)
            {
                //_context.Cities.Remove(MyCity);
                //_context.SaveChanges();
                _cityService.Delete(MyCity.Id);

            }
        }
    }
}