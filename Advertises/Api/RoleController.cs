using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;

namespace Roles.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private IBaseService<Role> _roleService;

        public RoleController(IBaseService<Role> roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {

            return _roleService.GetAll();
        }
        [HttpPost]
        public IActionResult Create([FromBody] RoleViewModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();


            Role MyRole = new Role();
            MyRole.CreateDate = DateTime.Now;


            MyRole.RoleName = inputModel.RoleName;
            MyRole.UserRoles = inputModel.UserRoles;



            _roleService.Insert(MyRole);


            return Ok(MyRole);

        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody]RoleViewModel inputModel)
        {
            if (inputModel == null || inputModel.Id == 0)
                return BadRequest();

            var MyRole =
                _roleService.GetAll()
                .FirstOrDefault(x => x.Id == inputModel.Id);


            MyRole.RoleName = inputModel.RoleName;
            MyRole.UserRoles = inputModel.UserRoles;


            _roleService.Update(MyRole);
            return Ok(MyRole);
        }
        [HttpPost]
        public IActionResult Delete([FromQuery] long id)
        {
            Role item = _roleService.Get(id);

            if (item == null)
            {
                return NotFound();
            }


            bool status = _roleService.Delete(item.Id);

            return Ok(status);

        }

    }
}