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
   
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertismentController : Controller
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



            MyAdvertisement.Title = inputModel.Title;
            MyAdvertisement.price = inputModel.price;
            MyAdvertisement.Images = inputModel.Images;
            MyAdvertisement.InnerCategory = inputModel.InnerCategory;
            MyAdvertisement.InnerCategoryId = inputModel.InnerCategoryId;
            MyAdvertisement.Local = inputModel.Local;
            MyAdvertisement.LocalId = inputModel.LocalId;
            MyAdvertisement.Description = inputModel.Description;
           
             await _advertismentService.Insert(MyAdvertisement);

            return Ok(MyAdvertisement);

        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]AdvertisementViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyAdvertisement =
                _advertismentService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);
                                  

            MyAdvertisement.Title = inputModel.Title;
            MyAdvertisement.Description = inputModel.Description;
            MyAdvertisement.IsActive = inputModel.IsActive;
            MyAdvertisement.InnerCategoryId = inputModel.InnerCategoryId;
            MyAdvertisement.Id = inputModel.Id;
            MyAdvertisement.LocalId = inputModel.LocalId;

            await _advertismentService.Update(MyAdvertisement);
            return Ok(MyAdvertisement);
        }

        [HttpPost]
        public IActionResult Delete([FromQuery] long id) 
        {
            Advertisement item = _advertismentService.Get(id);

            if (item == null)
            {
               return NotFound();
            }


            bool status = _advertismentService.Delete(item);

            return Ok(status);

        }




    }
}