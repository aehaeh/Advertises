using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;

namespace Users.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

       private IBaseService<User> _userService;

        public UserController(IBaseService<User> userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _userService.GetAll();
        }
        [HttpPost]
        public IActionResult Create([FromBody] UserViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            User MyUser = new User();
            MyUser.CreateDate = DateTime.Now;


            MyUser.FirstName = inputModel.FirstName;
            MyUser.LasttName = inputModel.LasttName;
            MyUser.Password = inputModel.Password;
            MyUser.PhoneNumber = inputModel.PhoneNumber;
            MyUser.UserName = inputModel.UserName;
            MyUser.UserRoles = inputModel.UserRoles;



            _userService.Insert(MyUser);


            return Ok(MyUser);

        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody]UserViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyUser =
                _userService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);


            MyUser.FirstName = inputModel.FirstName;
            MyUser.LasttName = inputModel.LasttName;
            MyUser.Password = inputModel.Password;
            MyUser.PhoneNumber = inputModel.PhoneNumber;
            MyUser.UserName = inputModel.UserName;
            MyUser.UserRoles = inputModel.UserRoles;


            _userService.Update(MyUser);
            return Ok(MyUser);
        }
        [HttpPost]
        public IActionResult Delete([FromQuery] long id)
        {
            User item = _userService.Get(id);

            if (item == null)
            {
                return NotFound();
            }


            bool status = _userService.Delete(item.Id);

            return Ok(status);

        }
    }
}