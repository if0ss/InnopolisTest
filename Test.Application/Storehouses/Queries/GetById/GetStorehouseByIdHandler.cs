using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;
using Test.Application.Storehouses.Dto;

namespace Test.Application.Storehouses.Queries.GetById
{
    public class GetStorehouseByIdHandler : IRequestHandler<GetStorehouseById, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStorehouseByIdHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IActionResult> Handle(GetStorehouseById request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestResponse("Request is null");

            var entity = await _dbContext.Storehouses.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (entity is null)
                return new NotFoundResponse($"Склад с идентификатором {request.Id} не найден");

            var dto = _mapper.Map<StorehouseDto>(entity);

            return new OkObjectResult(dto);
        }
    }
}