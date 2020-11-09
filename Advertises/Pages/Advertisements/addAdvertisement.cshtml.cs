using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises
{
    public class addAdvertisementModel : PageModel
    {
        private ApplicationDbContext _context;
        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListInnerCategories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListCities { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListLocations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListImages { get; set; } = new List<SelectListItem>();
        public List<string> FileNames { get; set; }
        public addAdvertisementModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public IFormFile[] photos
        {
            get;
            set;
        }

        [BindProperty]
        public Advertisement MyAdvertisement
        {
            set;
            get;
        }
        public long SelectedCity
        {
            get;
            set;
        }
        public long SelectedCategory
        {
            get;
            set;
        }
        public object InnerCategorie { get; private set; }

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
            var categories = _context.Categories.ToList();
            PopulateCategoryDropDownList(categories, null);
            var cities = _context.Cities.ToList();
            PopulateCityDropDownList(cities, null);
            var Locations = _context.Locations.ToList();
            PopulateLocalDropDownList(Locations, null);
            var innercategories = _context.InnerCategories.ToList();
            PopulateInnerCategoryDropDownList(innercategories, null);
        }
        public void OnPost()
        {
            MyAdvertisement.Images = new List<Image>();

            if (photos != null && photos.Length > 0)
            {
               
                foreach (IFormFile photo in photos)
                {
                    MyAdvertisement.Images.Add(new Image()
                    {
                        File = ConvertToBytes(photo)
                    });
                }
            }



            MyAdvertisement.CreateDate = DateTime.Now;
            MyAdvertisement.IsActive = false;
            _context.Advertisements.Add(MyAdvertisement);
            _context.SaveChanges();

        }
        public JsonResult OnGetChangeCity(long cityid)
        {

            var locations = _context.Locations
                .Where(x=>x.CityId==cityid)
                .ToList();
            

            return new JsonResult(locations);

        }
        public JsonResult OnGetChangeCategory(long categoryid)
        {

            var innercattegory = _context.InnerCategories
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