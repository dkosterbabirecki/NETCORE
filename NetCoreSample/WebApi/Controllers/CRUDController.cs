using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Interface;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CRUDController<Entity> : ControllerBase
    {
        private IService<Entity> service;

        public CRUDController(IService<Entity> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<Entity>> Get()
        {
            return Ok(service.Get());
        }

        [HttpGet("{id}")]
        public virtual ActionResult<Entity> Get(Guid id)
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
        public virtual ActionResult Post([FromBody] Entity value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(service.Add(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
        }


    }
}
