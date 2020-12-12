using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Advertises.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advertises.Controlers
{

    [Route("api/[controller]")]
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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
