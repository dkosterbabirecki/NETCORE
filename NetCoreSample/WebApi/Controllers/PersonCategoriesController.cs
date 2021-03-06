using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Services.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonCategoriesController : CRUDController<PersonCategory>
    {
        public PersonCategoriesController(IService<PersonCategory> service) : base(service)
        { }
    }
}
