using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises
{


    public class addAdvertisementModel : PageModel
    {

        private IAdvertismentService _advertismentService;
        private IBaseService<Category> _categoryService;
        private IBaseService<InnerCategory> _innerCategoryService;
        private IBaseService<Local> _localService;
        private IBaseService<City> _cityService;


        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListInnerCategories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListCities { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListLocations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListImages { get; set; } = new List<SelectListItem>();
        public List<string> FileNames { get; set; }


        [BindProperty]
        public AdvertisementViewModel MyAdvertisement
        { set; get; }
        public long SelectedCity
        { set; get; }
        public long SelectedCategory
        { set; get; }
        public object InnerCategorie { get; private set; }

        public addAdvertisementModel(IAdvertismentService advertismentService, IBaseService<Category> categoryService, IBaseService<InnerCategory> innerCategoryService, IBaseService<Local> localService, IBaseService<City> cityService)
        {
            _advertismentService = advertismentService;
            _categoryService = categoryService;
            _innerCategoryService = innerCategoryService;
            _localService = localService;
            _cityService = cityService;
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
        public void PopulateLocalDropDownList(IList<Local> Locations,
           List<long> selectedLocal)
        {
            var localQuery = from d in Locations
                             orderby d.Name // Sort by name.
                             select d;

            ListLocations = localQuery.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            }).ToList();
        }

        public void PopulateInnerCategoryDropDownList(IList<InnerCategory> InnerCategories,
           List<long> selectedInnerCategory)
        {
            var innercategoryQuery = from d in InnerCategories
                                     orderby d.Title // Sort by name.
                                     select d;

            ListInnerCategories = innercategoryQuery.Select(v => new SelectListItem
            {
                Text = v.Title,
                Value = v.Id.ToString()
            }).ToList();
        }


        public void OnGet()
        {
            var categories = _categoryService.GetAll().ToList();
            PopulateCategoryDropDownList(categories, null);
            var cities = _cityService.GetAll().ToList();
            PopulateCityDropDownList(cities, null);
            var Locations = _localService.GetAll().ToList();
            PopulateLocalDropDownList(Locations, null);
            var innercategories = _innerCategoryService.GetAll().ToList();
            PopulateInnerCategoryDropDownList(innercategories, null);
        }

        public IActionResult OnPost(List<IFormFile> files)
        {

            if (ModelState.IsValid)
            {
                MyAdvertisement.Images = new List<Image>();

                if (files != null && files.Count > 0)
                {

                    foreach (IFormFile uploadedFile in files)
                    {
                        MyAdvertisement.Images.Add(new Image()
                        {
                            File = ConvertToBytes(uploadedFile)
                        });
                    }
                }




                MyAdvertisement.CreateDate = DateTime.Now;
                MyAdvertisement.IsActive = false;

                Advertisement persistAdvertisement = new Advertisement();

                persistAdvertisement.Title = MyAdvertisement.Title;
                persistAdvertisement.price = MyAdvertisement.price;
                persistAdvertisement.Id = MyAdvertisement.Id;
                persistAdvertisement.Images = MyAdvertisement.Images;
                persistAdvertisement.InnerCategory = MyAdvertisement.InnerCategory;
                persistAdvertisement.InnerCategoryId = MyAdvertisement.InnerCategoryId;
                persistAdvertisement.IsActive = MyAdvertisement.IsActive;
                persistAdvertisement.Local = MyAdvertisement.Local;
                persistAdvertisement.LocalId = MyAdvertisement.LocalId;
                persistAdvertisement.UpdatedDate = MyAdvertisement.UpdatedDate;
                persistAdvertisement.CreateDate = MyAdvertisement.CreateDate;
                persistAdvertisement.Description = MyAdvertisement.Description;

                //_context.Advertisements.Add(persistAdvertisement);
                //_context.SaveChanges();
                _advertismentService.Insert(persistAdvertisement);
            }


            return Page();

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

        private byte[] ConvertToBytes(IFormFile file)
        {
            Stream stream = file.OpenReadStream();
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }



        }
    }
}