﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Advertises.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


       
        private IAdvertismentService _advertismentService;

        public IndexModel(IAdvertismentService advertismentService)
        {
            _advertismentService = advertismentService;
        }

        [BindProperty]
        public IList<Advertisement> Advertisements
        {
            get;
            set;
        }
        [BindProperty]
        public string Mysearch
        {
            set;
            get;

        }


        public void OnGet()
        {



            Advertisements = _advertismentService.GetAll()
                .Include(x => x.Images)
                .Include(x => x.Local)
                .ThenInclude(x => x.City)
                .ToList();


            foreach (Advertisement iteam in Advertisements)
            {
                if (iteam.Images != null && iteam.Images.Count > 0)
                {
                    iteam.SelectedImage = "data:image/png;base64,"+ Convert.ToBase64String(iteam.Images.First().File);
                }
            }
        }

        public void OnPost()
        {

            //Advertisements = _context.Advertisements.Where(x => x.Title.Contains(Mysearch)).ToList();
            Advertisements = _advertismentService.GetAll().ToList();
        }
    }
}
