using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Test.Application.ProductStorehouses.Commands.Add;
using Test.Application.ProductStorehouses.Commands.ChangeCount;
using Test.Application.ProductStorehouses.Commands.Delete;
using Test.Application.ProductStorehouses.Dto;
using Test.Application.ProductStorehouses.Queries.GetById;
using Test.Application.ProductStorehouses.Queries.GetList;
using Test.Application.ResponsesDto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Test.Application;
using Test.Application.ProductStorehouses.Commands.Patch;
using Test.Domain;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStorehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAppDbContext _dbContext;

        public ProductStorehouseController(IMediator mediator, IAppDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получение товара на складе по идентификатору
        /// </summary>
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductStorehouseDto), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return await _mediator.Send(new GetProductStorehouseById(id));
        }

        /// <summary>
        /// Получение списка товара на складе
        /// </summary>
        [ProducesResponseType(typeof(List<ProductStorehouseListDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductStorehouseList request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Добавление товара на склад
        /// </summary>
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductStorehouse request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Удаление товара со склада
        /// </summary>
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
            return await _mediator.Send(new DeleteProductStorehouse(id));
        }

        /// <summary>
        /// Изменение количества товара на складе
        /// </summary>
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeCount(int id, [FromBody] JsonPatchDocument<UpdatePatchProductStorehouseDto> patchEntity)
        {
            return await _mediator.Send(new UpdatePatchProductStorehouse(patchEntity, id));
        }
    }
}
