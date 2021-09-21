using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Test.Application.Products.Commands.Add;
using Test.Application.Products.Commands.Update;

namespace Test.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProduct request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProduct request)
        {
            return await _mediator.Send(request);
        }

    }
}
