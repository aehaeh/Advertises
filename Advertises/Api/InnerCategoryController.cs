using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;

namespace InnerCategories.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InnerCategoryController : ControllerBase
    {

        private IBaseService<InnerCategory> _innerCategoryService;

        public InnerCategoryController(IBaseService<InnerCategory> innerCategoryService)
        {
            _innerCategoryService = innerCategoryService;
        }



        [HttpGet]
        public IEnumerable<InnerCategory> Get()
        {

            return _innerCategoryService.GetAll();
        }
        [HttpPost]
        public IActionResult Create([FromBody] InnerCategoryViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            InnerCategory MyInnerCategory = new InnerCategory();
            MyInnerCategory.CreateDate = DateTime.Now;


            MyInnerCategory.Title = inputModel.Title;
            MyInnerCategory.Advertisements = inputModel.Advertisements;
            MyInnerCategory.CategoryId = inputModel.CategoryId;



            _innerCategoryService.Insert(MyInnerCategory);


            return Ok(MyInnerCategory);

        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody]InnerCategoryViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyInnerCategory =
                _innerCategoryService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);


            MyInnerCategory.Title = inputModel.Title;
            MyInnerCategory.Advertisements = inputModel.Advertisements;



            _innerCategoryService.Update(MyInnerCategory);
            return Ok(MyInnerCategory);
        }
        [HttpPost]
        public IActionResult Delete([FromQuery] long id)
        {
            InnerCategory item = _innerCategoryService.Get(id);

            if (item == null)
            {
                return NotFound();
            }


            bool status = _innerCategoryService.Delete(item.Id);

            return Ok(status);

        }
    }
}