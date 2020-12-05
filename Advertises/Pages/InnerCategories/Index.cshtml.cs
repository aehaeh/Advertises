using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.InnerCategories
{
    public class IndexModel : PageModel
    {
        private IBaseService<InnerCategory> _innerCategoryService;

        public IndexModel(IBaseService<InnerCategory> innerCategoryService)
        {
            _innerCategoryService = innerCategoryService;
        }

       
        [BindProperty]
        public IList<InnerCategory> InnerCategories
        {
            get;
            set;
        }
        public DbSet<Advertisement> Advertisementlist { get; private set; }
        public void OnGet()
        {
            InnerCategories = _innerCategoryService.GetAll().ToList();
        }
    }
}