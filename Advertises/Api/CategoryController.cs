using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Service;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;




namespace Categories.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private IBaseService<Category> _categoryService;

        public CategoryController(IBaseService<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
           
            return _categoryService.GetAll();
        }
        [HttpPost]
        public IActionResult Create([FromBody] CategoryViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            Category MyCategory = new Category();
            MyCategory.CreateDate = DateTime.Now;
            

            MyCategory.Title = inputModel.Title;
            MyCategory.advertisements = inputModel.advertisements;

             _categoryService.Insert(MyCategory);
            

            return Ok(MyCategory);

        }



        [HttpPost]
        public async Task<IActionResult> Update([FromBody]CategoryViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyCategory =
                _categoryService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);


            MyCategory.Title = inputModel.Title;
           

             _categoryService.Update(MyCategory);
            return Ok(MyCategory);
        }

        [HttpPost]
        public IActionResult Delete([FromQuery] long id)
        {
            Category item = _categoryService.Get(id);

            if (item == null)
            {
                return NotFound();
            }


            bool status = _categoryService.Delete(item.Id);

            return Ok(status);

        }


    }
}