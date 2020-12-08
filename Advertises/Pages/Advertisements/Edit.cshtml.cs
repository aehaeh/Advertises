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


        [BindProperty(SupportsGet =true)]
        public AdvertisementViewModel MyAdvertisement
        { set; get; }
        public IList<Advertisement> Advertisements
        { set; get; }
        [BindProperty]
        public List<long> SelectedImagesId { set; get; }


        public void OnGet(long id)
        {

            //var categories = _context.Categories.ToList();
            var categories = _categoryService.GetAll().ToList();
            PopulateCategoryDropDownList(categories, null);



            var localAdvertisement =
                _advertismentService.GetAll()
                  .Include(x => x.Images)
                  .FirstOrDefault(x => x.Id == id);

            MyAdvertisement.Id = localAdvertisement.Id;
            MyAdvertisement.Category = localAdvertisement.Category;
            MyAdvertisement.CreateDate = localAdvertisement.CreateDate;
            MyAdvertisement.Images = localAdvertisement.Images;
            MyAdvertisement.InnerCategory = localAdvertisement.InnerCategory;
            MyAdvertisement.InnerCategoryId = localAdvertisement.InnerCategoryId;
            MyAdvertisement.IsActive = localAdvertisement.IsActive;
            MyAdvertisement.Local = localAdvertisement.Local;
            MyAdvertisement.LocalId = localAdvertisement.LocalId;
            MyAdvertisement.price = localAdvertisement.price;
            MyAdvertisement.SelectedImage = localAdvertisement.SelectedImage;
            MyAdvertisement.Title = localAdvertisement.Title;
            MyAdvertisement.UpdatedDate = localAdvertisement.UpdatedDate;

            







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
            
          
            ttt.Id = MyAdvertisement.Id;
            ttt.Images = MyAdvertisement.Images;
            ttt.InnerCategory = MyAdvertisement.InnerCategory;
            ttt.Local = MyAdvertisement.Local;
            ttt.LocalId = MyAdvertisement.LocalId;
            ttt.UpdatedDate = MyAdvertisement.UpdatedDate;
            ttt.CreateDate = MyAdvertisement.CreateDate;
            ttt.Description = MyAdvertisement.Description;

            // _context.Advertisements.Update(ttt);
            // _context.SaveChanges();
            _advertismentService.Update(ttt);

           
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