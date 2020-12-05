using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.Categories
{
    public class IndexModel : PageModel
       
    {
        private IBaseService<Category> _categoryService;
        

        public IndexModel(IBaseService<Category> categoryService )
        {
            _categoryService = categoryService;
        }
        [BindProperty]
        public IList<Category> Categories 
        {
            get;
            set; 
        }
      
        public DbSet<Advertisement> Advertisementlist { get; private set; }

        public void OnGet()
        {
            //Categories = _context.Categories.ToList();
            Categories = _categoryService.GetAll().ToList();
        }

       
      
    }
}