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
using Test.Application.Products.Queries.GetList;
using Test.Application.ResponsesDto;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавление товара
        /// </summary>
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProduct request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Изменение товара
        /// </summary>
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProduct request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Получение товара по идентификатору
        /// </summary>
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return await _mediator.Send(new GetProductById(id));
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        [ProducesResponseType(typeof(List<ProductListDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetProductsList request)
        {
            return await _mediator.Send(request);
        }
    }
}
