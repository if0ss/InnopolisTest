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

            var dto = await _dbContext.Storehouses.Where(e => e.Id == request.Id)
                .ProjectTo<StorehouseDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);

            return new OkObjectResult(dto);
        }
    }
}