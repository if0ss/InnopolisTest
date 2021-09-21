using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Test.Application.Products.Commands.Add;
using Test.Application.Products.Commands.Update;
using Test.Application.Products.Dto;
using Test.Application.Products.Queries.GetById;
using Test.Application.ResponsesDto;

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

        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProduct request)
        {
            return await _mediator.Send(request);
        }

        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProduct request)
        {
            return await _mediator.Send(request);
        }

        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetProductById request)
        {
            return await _mediator.Send(request);
        }
    }
}
