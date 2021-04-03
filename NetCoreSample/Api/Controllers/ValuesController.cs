using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using BusinessLogic.Interface;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IService<Person> service;

        public PersonController(IService<Person> service)
        {
            this.service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(service.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(Guid id)
        {
            var person = service.Get(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person value)
        {
            return Ok(service.Add(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
