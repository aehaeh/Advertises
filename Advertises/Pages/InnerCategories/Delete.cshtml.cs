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
    public class DeleteModel : PageModel
    {
       
        private IBaseService<InnerCategory> _innerCategoryService;

        public DeleteModel(IBaseService<InnerCategory> innerCategoryService)
        {
            _innerCategoryService = innerCategoryService;
        }

        
        [BindProperty]
        public InnerCategory MyInnerCategory
        {
            set;
            get;
        }
        public void OnGet(long id)
        {
            MyInnerCategory = _innerCategoryService.Get(id);
        }
        public void OnPost()
        {
           
            if (MyInnerCategory != null)
            {
                _innerCategoryService.Delete(MyInnerCategory.Id);
                
            }
        }
    }
}