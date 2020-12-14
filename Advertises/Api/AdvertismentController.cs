using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Advertises.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advertises.Api
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AdvertismentController:Controller
    {
        private IAdvertismentService _advertismentService;


        public AdvertismentController(IAdvertismentService advertismentService)
        {
            _advertismentService = advertismentService;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Advertisement> Get()
        {
            //return new string[] { "value1", "value2" };
            return _advertismentService.GetAll();
        }
       
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdvertisementViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            Advertisement MyAdvertisement = new Advertisement();
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

           persistAdvertisement =await _advertismentService.Insert(persistAdvertisement);

            return Ok(persistAdvertisement);

        }




    }
}