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


        }
    }
}