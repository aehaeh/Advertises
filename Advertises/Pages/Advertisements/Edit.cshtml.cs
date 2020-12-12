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
        private IBaseService<City> _cityService;
        private IBaseService<Local> _localService;
        private IBaseService<InnerCategory> _innerCategoryService;

        public EditModel(IAdvertismentService advertismentService, IBaseService<Category> categoryService,IBaseService<City> cityService, IBaseService<Local> localService,IBaseService<InnerCategory> innerCategoryService)
        {
            _advertismentService = advertismentService;
            _categoryService = categoryService;
            _cityService = cityService;
            _localService = localService;
            _innerCategoryService = innerCategoryService;
        }

        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListCities { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListLocations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListInnerCategories { get; set; } = new List<SelectListItem>();

        public long SelectedCity
        { set; get; }
        public long SelectedCategory
        { set; get; }

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
            var cities = _cityService.GetAll().ToList();
            PopulateCityDropDownList(cities, null);
            var locations = _localService.GetAll().ToList();
            PopulateLocalDropDownList(locations,null);
            var innerCategories = _innerCategoryService.GetAll().ToList();
            PopulateInnerCategoryDropDownList(innerCategories,null);

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
        public async Task<IActionResult> OnPostAsync()
        {
            var persistAdvertisement = _advertismentService.GetAll().Include(x => x.Images).FirstOrDefault(x => x.Id == MyAdvertisement.Id);

            foreach (long imageId in SelectedImagesId)
            {
                persistAdvertisement.Images.Remove(persistAdvertisement.Images.FirstOrDefault(x => x.Id == imageId));
            }


            persistAdvertisement.Title = MyAdvertisement.Title;
            persistAdvertisement.Description = MyAdvertisement.Description;
            persistAdvertisement.IsActive = MyAdvertisement.IsActive;
            persistAdvertisement.InnerCategoryId = MyAdvertisement.InnerCategoryId;
            persistAdvertisement.Id = MyAdvertisement.Id;                        
            persistAdvertisement.LocalId = MyAdvertisement.LocalId;
            persistAdvertisement.UpdatedDate = DateTime.Now;            
           
            // _context.Advertisements.Update(ttt);
            // _context.SaveChanges();
            await _advertismentService.Update(persistAdvertisement);
            MyAdvertisement.Images= persistAdvertisement.Images;

            var categories = _categoryService.GetAll().ToList();
            PopulateCategoryDropDownList(categories, null);


            return Page();
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
        public void PopulateCityDropDownList(IList<City> cities,
          List<long> selectedCity)
        {
            var cityQuery = from d in cities
                                orderby d.Name // Sort by name.
                                select d;

            ListCities = cityQuery.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            }).ToList();
        }

        public void PopulateLocalDropDownList(IList<Local> locations,
          List<long> selectedLocal)
        {
            var localQuery = from d in locations
                            orderby d.Name // Sort by name.
                            select d;

            ListLocations = localQuery.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            }).ToList();
        }
        public void PopulateInnerCategoryDropDownList(IList<InnerCategory> innerCategories,
           List<long> selectedCategory)
        {
            var innerCategoryQuery = from d in innerCategories
                                orderby d.Title // Sort by name.
                                select d;

            ListInnerCategories = innerCategoryQuery.Select(v => new SelectListItem
            {
                Text = v.Title,
                Value = v.Id.ToString()
            }).ToList();
        }
        public JsonResult OnGetChangeCity(long cityid)
        {

            var locations = _localService.GetAll()
                .Where(x => x.CityId == cityid)
                .ToList();


            return new JsonResult(locations);

        }
        public JsonResult OnGetChangeCategory(long categoryid)
        {

            var innercattegory = _innerCategoryService.GetAll()
                .Where(x => x.CategoryId == categoryid)
                .ToList();


            return new JsonResult(innercattegory);

        }
    }
}