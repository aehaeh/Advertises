﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.Categories
{
    public class IndexModel : PageModel
       
    {
       private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
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
            Categories = _context.Categories.ToList();

        }

       
      
    }
}