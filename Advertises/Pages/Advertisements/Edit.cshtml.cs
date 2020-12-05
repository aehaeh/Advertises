using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Advertises
{
    public class EditModel : PageModel
    {
        private IAdvertismentService _advertismentService;
        private IBaseService<Category> _categoryService;

        public EditModel(IAdvertismentService advertismentService, IBaseService<Category> categoryService)
        {
            _advertismentService = advertismentService;
            _categoryService = categoryService;
        }

        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();


        [BindProperty]
        public Advertisement MyAdvertisement
        {
            get;
            set;
        }
        public IList<Advertisement> Advertisements
        {
            get;
            set;
        }
        [BindProperty]
        public List<long> SelectedImagesId { set; get; }


        public void OnGet(long id)
        {

            //var categories = _context.Categories.ToList();
            var categories = _categoryService.GetAll().ToList();
            PopulateCategoryDropDownList(categories, null);
            MyAdvertisement = _advertismentService.GetAll()
                  .Include(x => x.Images)
                 .FirstOrDefault(x => x.Id == id);



        }
        public void OnPost()
        {
            var ttt = _advertismentService.GetAll().Include(x => x.Images).FirstOrDefault(x => x.Id == MyAdvertisement.Id);

            foreach (long imageId in SelectedImagesId)
            {
                ttt.Images.Remove(ttt.Images.FirstOrDefault(x => x.Id == imageId));
            }

            ttt.Title = MyAdvertisement.Title;
            ttt.Description = MyAdvertisement.Description;
            ttt.IsActive = MyAdvertisement.IsActive;
            ttt.InnerCategoryId = MyAdvertisement.InnerCategoryId;


           // _context.Advertisements.Update(ttt);
           // _context.SaveChanges();
            _advertismentService.Update(ttt);
            MyAdvertisement = _advertismentService.GetAll()
                 .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == MyAdvertisement.Id);

            var categories = _categoryService.GetAll().ToList();
            PopulateCategoryDropDownList(categories, null);

        }
        public void PopulateCategoryDropDownList(IList<Category> categories,
           List<long> selectedCategory)
        {
            var categoryQuery = from d in categories
                                orderby d.Title // Sort by name.
                                select d;

            ListCategories = categoryQuery.Select(v => new SelectListItem
            {
                Text = v.Title,
                Value = v.Id.ToString()
            }).ToList();
        }
    }
}