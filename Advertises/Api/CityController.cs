using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;

using Microsoft.AspNetCore.Mvc;

namespace Cities.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private IBaseService<City> _cityService;

        public CityController(IBaseService<City> cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public IEnumerable<City> Get()
        {

            return _cityService.GetAll();
        }
        [HttpPost]
        public IActionResult Create([FromBody] CityViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            City MyCity = new City();
            MyCity.CreateDate = DateTime.Now;


            MyCity.Name = inputModel.Name;
            MyCity.Locals = inputModel.Locals;




            _cityService.Insert(MyCity);


            return Ok(MyCity);

        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody]CityViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyCity =
                _cityService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);


            MyCity.Name = inputModel.Name;


            _cityService.Update(MyCity);
            return Ok(MyCity);
        }
        [HttpPost]
        public IActionResult Delete([FromQuery] long id)
        {
            City item = _cityService.Get(id);

            if (item == null)
            {
                return NotFound();
            }


            bool status = _cityService.Delete(item.Id);

            return Ok(status);

        }
    }
}