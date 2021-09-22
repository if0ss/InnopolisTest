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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StorehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStorehouse request)
        {
            return await _mediator.Send(request);
        }

        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStorehouse request)
        {
            return await _mediator.Send(request);
        }

        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(StorehouseDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetStorehouseById request)
        {
            return await _mediator.Send(request);
        }

        [ProducesResponseType(typeof(List<StorehouseListDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetStorehousesList request)
        {
            return await _mediator.Send(request);
        }
    }
}
