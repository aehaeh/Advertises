﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public City MyCity
        {
            set;
            get;
        }

        public void OnGet(int? id)
        {
            MyCity = _context.Cities.SingleOrDefault(m => m.Id == id);
        }
        public void OnPost(int? id)
        {
            _context.Cities.SingleOrDefault(m => m.Id == id);
            if (MyCity != null)
            {
                _context.Cities.Remove(MyCity);
                _context.SaveChanges();
            }
        }
    }
}