using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class DeleteCategoryModel : PageModel
    {

        private ApplicationDbContext _context;

        public DeleteCategoryModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]

        public Category MyCategory
        {
            set;
            get;
        }
        public void OnGet(int? id)
        {
           MyCategory= _context.Categories.SingleOrDefault(m => m.Id == id);
            
        }
        public void OnPost(int? id)
        {
            _context.Categories.SingleOrDefault(m => m.Id == id);
            if (MyCategory != null)
            {
                _context.Categories.Remove(MyCategory);
                _context.SaveChanges();
            }
        }
    }
}