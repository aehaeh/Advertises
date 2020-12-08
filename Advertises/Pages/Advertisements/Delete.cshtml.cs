using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Advertisements

{
    public class DeleteModel : PageModel
    {
        private IAdvertismentService _advertismentService;



        public DeleteModel(IAdvertismentService advertismentService)
        {
            _advertismentService = advertismentService;
        }
        [BindProperty]
        public Advertisement Myadvrtisment
        { set; get; }


        public void OnGet(long id)
        {
           Myadvrtisment= _advertismentService.Get(id);
           
        }
        public void OnPost()
        {
            if (Myadvrtisment != null)
            {
                _advertismentService.Delete(Myadvrtisment);                
            }

           // RedirectToPage("/Advertisements/Index");
            
            
        }
    }
}

