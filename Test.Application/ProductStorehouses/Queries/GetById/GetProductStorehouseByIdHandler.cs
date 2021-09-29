using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ProductStorehouses.Dto;
using Test.Application.ResponsesDto;

namespace Test.Application.ProductStorehouses.Queries.GetById
{
    public class GetProductStorehouseByIdHandler : IRequestHandler<GetProductStorehouseById, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductStorehouseByIdHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IActionResult> Handle(GetProductStorehouseById request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestResponse("Request is null");

            var entity = await _dbContext.ProductStorehouses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if(entity is null)
                return new NotFoundResponse($"Товар на складе с идентификатором {request.Id} не найден");

            var dto = _mapper.Map<ProductStorehouseDto>(entity);

            return new OkObjectResult(dto);
        }
    }
}