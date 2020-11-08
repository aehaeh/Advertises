using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Advertises.Models;
using Microsoft.EntityFrameworkCore;

namespace DataFiller
{
    public class App
    {
        private readonly ApplicationDbContext _context;

        public App(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Run()
        {
            Console.WriteLine("......wellcome.................");
            Console.WriteLine("step1 : init databa base");
            
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();


            var city1 = new City()
            {
                Name = "تهران",
                CreateDate = DateTime.Now,
                IsActive = false
            };
            



            _context.Cities.Add(city1);
            _context.SaveChanges();

            var city2 = new City()
            {
                Name = "مهشد",
                CreateDate = DateTime.Now,
                IsActive = false
            };




            _context.Cities.Add(city2);
            _context.SaveChanges();

            var city3 = new City()
            {
                Name = "اصفهان",
                CreateDate = DateTime.Now,
                IsActive = false
            };




            _context.Cities.Add(city3);
            _context.SaveChanges();


            var city4 = new City()
            {
                Name = "یزد",
                CreateDate = DateTime.Now,
                IsActive = false
            };




            _context.Cities.Add(city4);
            _context.SaveChanges();




            var local1 = new Local()
            {
                Name = "انقلاب",
                CreateDate = DateTime.Now,
                CityId = city1.Id,
                IsActive = false
              
            };




            _context.Locations.Add(local1);
            _context.SaveChanges();





            var local2 = new Local()
            {
                Name = "ربیع",
                CreateDate = DateTime.Now,
                CityId = city2.Id,
                IsActive = false

            };




            _context.Locations.Add(local2);
            _context.SaveChanges();


            var local3 = new Local()
            {
                Name = "سی و سه پل",
                CreateDate = DateTime.Now,
                CityId = city3.Id,
                IsActive = false

            };




            _context.Locations.Add(local3);
            _context.SaveChanges();

            var local4 = new Local()
            {
                Name = "اردکان",
                CreateDate = DateTime.Now,
                CityId = city4.Id,
                IsActive = false

            };




            _context.Locations.Add(local4);
            _context.SaveChanges();


            var category1 = new Category()
            {
                Title = "لوازم خانگی",
                CreateDate = DateTime.Now,
      

            };




            _context.Categories.Add(category1);
            _context.SaveChanges();



            var category2 = new Category()
            {
                Title = "لوازم خودرو ",
                CreateDate = DateTime.Now,


            };




            _context.Categories.Add(category2);
            _context.SaveChanges();

            var category3 = new Category()
            {
                Title = "لوازم دیجیتال ",
                CreateDate = DateTime.Now,


            };




            _context.Categories.Add(category3);
            _context.SaveChanges();







             var innercategory1 = new InnerCategory()
            {
                Title = "لوازم آشپزخانه ",
                CategoryId = category1.Id,


            };




            _context.InnerCategories.Add(innercategory1);
            _context.SaveChanges();




            var innercategory2 = new InnerCategory()
            {
                Title = " دکوراسون داخلی  ",
                CategoryId = category1.Id,


            };




            _context.InnerCategories.Add(innercategory2);
            _context.SaveChanges();


            var innercategory3 = new InnerCategory()
            {
                Title = " لوازم  داخلی  ",
                CategoryId = category2.Id,


            };




            _context.InnerCategories.Add(innercategory3);
            _context.SaveChanges();

            var innercategory4 = new InnerCategory()
            {
                Title = " لوازم جانبی ماشین   ",
                CategoryId = category2.Id,


            };




            _context.InnerCategories.Add(innercategory4);
            _context.SaveChanges();

            var innercategory5 = new InnerCategory()
            {
                Title = " لبتاب و لوازم جانبی    ",
                CategoryId = category3.Id,


            };




            _context.InnerCategories.Add(innercategory5);
            _context.SaveChanges();

            var innercategory6 = new InnerCategory()
            {
                Title = " انواع هارد   ",
                CategoryId = category3.Id,


            };




            _context.InnerCategories.Add(innercategory6);
            _context.SaveChanges();

            var advertisment1 = new Advertisement()
            {
               Description="قاشق های استیل",
               CreateDate = DateTime.Now,
               price= 90182,
               InnerCategoryId=innercategory1.Id,
               LocalId=local1.Id,
                IsActive = true
            };




            _context.Advertisements.Add(advertisment1);
            _context.SaveChanges();



            var advertisment2 = new Advertisement()
            {
                Description = "لاستیک های بارز ایران",
                CreateDate = DateTime.Now,
                price = 9000182,
                InnerCategoryId = innercategory4.Id,
                LocalId = local4.Id,
                IsActive = true
            };




            _context.Advertisements.Add(advertisment2);
            _context.SaveChanges();





        }







    }








    }


