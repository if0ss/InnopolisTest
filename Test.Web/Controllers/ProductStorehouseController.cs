using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStorehouseController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> AddProduct()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<IActionResult> DeleteProduct()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public Task<IActionResult> ChangeCount()
        {
            throw new NotImplementedException();
        }
    }
}
