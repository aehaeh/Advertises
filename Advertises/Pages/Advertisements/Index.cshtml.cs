using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.Advertisements
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string SelectetImage
        { set; get; }

        public IList<Advertisement> Advrtiseslist
        { set; get; }
        public void OnGet()
        {

            Advrtiseslist = _context.Advertisements
                .Include(x=> x.Images)
                .Include(x => x.Local)
                .ThenInclude(x => x.City)
                .OrderByDescending(x => x.CreateDate).ToList()
                ;
            foreach (Advertisement item in Advrtiseslist)
            {
                if(item.Images != null && item.Images.Count > 0)
                {
                    item.SelectedImage = "data:image/png;base64," + Convert.ToBase64String(item.Images.First().File);
                }
            }
        }
        public void OnPost()
        {

        }
    }
}