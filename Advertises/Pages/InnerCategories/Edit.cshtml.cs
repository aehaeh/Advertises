using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.InnerCategories
{
    public class EditModel : PageModel
    {

        
        private IBaseService<InnerCategory> _innerCategoryService;

        public EditModel(IBaseService<InnerCategory> innerCategoryService)
        {
            _innerCategoryService = innerCategoryService;
        }

        [BindProperty]
        public InnerCategory MyInnerCategory
        { set; get; }

        public void OnGet(long id)
        {
            MyInnerCategory = _innerCategoryService.Get( id);
        }
        public void Onpost()
        {
            //var tt = _context.InnerCategories.FirstOrDefault(x => x.Id == MyInnerCategory.Id);
            //tt.Title = MyInnerCategory.Title;
            var tt = _innerCategoryService.Get(MyInnerCategory.Id);
            tt.Title = MyInnerCategory.Title;

            _innerCategoryService.Update(tt);
            
        }
    }
}