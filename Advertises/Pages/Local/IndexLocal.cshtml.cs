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
    public class IndexLocalModel : PageModel
    {
        
        private IBaseService<Local> _localService;

        public IndexLocalModel(IBaseService<Local> localService)
        {
            _localService = localService;
        }

        [BindProperty]
        public IList<Local> Locations
        { set; get; }
        public DbSet<Advertisement> Advertisementlist { get; private set; }
        public void OnGet()
        {
           Locations = _localService.GetAll().ToList();
        }
    }
}