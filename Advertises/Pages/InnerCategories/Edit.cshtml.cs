using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
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
        public InnerCategoryViewModel MyInnerCategory
        { set; get; }

        public void OnGet(long id)
        {
            var localInnercategory = _innerCategoryService.Get( id);
            MyInnerCategory.Id = localInnercategory.Id;
            MyInnerCategory.Advertisements = localInnercategory.Advertisements;
            MyInnerCategory.CategoryId = localInnercategory.CategoryId;
            MyInnerCategory.CreateDate = localInnercategory.CreateDate;
            MyInnerCategory.Title = localInnercategory.Title;
            MyInnerCategory.UpdatedDate = localInnercategory.UpdatedDate;
        }
        public void Onpost()
        {
            //var tt = _context.InnerCategories.FirstOrDefault(x => x.Id == MyInnerCategory.Id);
            //tt.Title = MyInnerCategory.Title;
            var tt = _innerCategoryService.Get(MyInnerCategory.Id);
            tt.Title = MyInnerCategory.Title;
            tt.Advertisements = MyInnerCategory.Advertisements;
            tt.CategoryId = MyInnerCategory.CategoryId;
            tt.CreateDate = MyInnerCategory.CreateDate;
            tt.Id = MyInnerCategory.Id;
            tt.UpdatedDate = MyInnerCategory.UpdatedDate;
            
            

            _innerCategoryService.Update(tt);
            
        }
    }
}