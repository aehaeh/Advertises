using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;

namespace Location.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocalController : ControllerBase
    {

        private IBaseService<Local> _localService;

        public LocalController(IBaseService<Local> localService)
        {
            _localService = localService;
        }

        [HttpGet]
        public IEnumerable<Local> Get()
        {

            return _localService.GetAll();
        }
        [HttpPost]
        public IActionResult Create([FromBody] LocalViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            Local MyLocal = new Local();
            MyLocal.CreateDate = DateTime.Now;


            MyLocal.Name = inputModel.Name;
            MyLocal.CityId = inputModel.CityId;



            _localService.Insert(MyLocal);


            return Ok(MyLocal);

        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody]CityViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyLocal =
                _localService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);


            MyLocal.Name = inputModel.Name;


            _localService.Update(MyLocal);
            return Ok(MyLocal);
        }
        [HttpPost]
        public IActionResult Delete([FromQuery] long id)
        {
            Local item = _localService.Get(id);

            if (item == null)
            {
                return NotFound();
            }


            bool status = _localService.Delete(item.Id);

            return Ok(status);

        }
    }
}