using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Test.Application.Storehouses.Commands.Add;
using Test.Application.Storehouses.Commands.Update;
using Test.Application.Storehouses.Dto;
using Test.Application.Storehouses.Queries.GetById;
using Test.Application.Storehouses.Queries.GetList;
using Test.Application.ResponsesDto;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorehousesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StorehousesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавление склада
        /// </summary>
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStorehouse request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Изменение склада
        /// </summary>
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStorehouse request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Получение склада по идентификатру
        /// </summary>
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(StorehouseDto), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return await _mediator.Send(new GetStorehouseById(id));
        }

        /// <summary>
        /// Получение списка складов
        /// </summary>
        [ProducesResponseType(typeof(List<StorehouseListDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetStorehousesList request)
        {
            return await _mediator.Send(request);
        }
    }
}
