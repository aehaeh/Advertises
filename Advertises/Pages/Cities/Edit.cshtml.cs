using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
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

       
        [BindProperty(SupportsGet = true)]
        public CityViewModel MyCity
        { set; get; }


        public void OnGet(long id)
        {
            //MyCity = _context.Cities.FirstOrDefault(x => x.Id == id);
           var localCity  = _cityService.Get(id);
            MyCity.IsActive = localCity.IsActive;
            MyCity.Id = localCity.Id;
            MyCity.CreateDate = localCity.CreateDate;
            MyCity.Locals = localCity.Locals;
            MyCity.Name = localCity.Name;
            MyCity.UpdatedDate = localCity.UpdatedDate;
        }
        public void Onpost()
        {
            //var tt = _context.Cities.FirstOrDefault(x => x.Id == MyCity.Id);
            //tt.Name = MyCity.Name;

            //_context.Cities.Update(tt);
            //_context.SaveChanges();
            var tt = _cityService.Get(MyCity.Id);
            tt.CreateDate = MyCity.CreateDate;
            tt.Name = MyCity.Name;
            tt.Id = MyCity.Id;
            tt.IsActive = MyCity.IsActive;
            tt.Locals = MyCity.Locals;
            tt.UpdatedDate = MyCity.UpdatedDate;
           


            _cityService.Update(tt);
          
        }
    }
}