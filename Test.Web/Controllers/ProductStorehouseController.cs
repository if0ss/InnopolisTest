using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Test.Application.ProductStorehouses.Dto;
using Test.Application.ProductStorehouses.Queries.GetById;
using Test.Application.ProductStorehouses.Queries.GetList;
using Test.Application.ResponsesDto;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStorehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductStorehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получение товара на складе по идентификатору
        /// </summary>
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductStorehouseDto), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("{id:int}")]
        public Task<IActionResult> Get(int id)
        {
            return _mediator.Send(new GetProductStorehouseById(id));
        }

        /// <summary>
        /// Получение списка товара на складе
        /// </summary>
        [ProducesResponseType(typeof(List<ProductStorehouseListDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public Task<IActionResult> Get([FromQuery] GetProductStorehouseList request)
        {
            return _mediator.Send(request);
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
