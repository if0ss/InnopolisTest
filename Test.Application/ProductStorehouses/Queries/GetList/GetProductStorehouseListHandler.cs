using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ProductStorehouses.Dto;

namespace Test.Application.ProductStorehouses.Queries.GetList
{
    public class GetProductStorehouseListHandler : IRequestHandler<GetProductStorehouseList, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductStorehouseListHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IActionResult> Handle(GetProductStorehouseList request, CancellationToken cancellationToken)
        {
            var query = _dbContext.ProductStorehouses.AsQueryable();

            if (request?.StorehouseId != null)
                query = query.Where(e => e.StorehouseId == request.StorehouseId);

            if (request?.ProductId != null)
                query = query.Where(e => e.ProductId == request.ProductId);

            if (request?.IsExist != null)
                query = request.IsExist.Value ? query.Where(e => e.Count > 0) : query.Where(e => e.Count == 0);

            return new OkObjectResult(await query.ProjectTo<ProductStorehouseListDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
        }
    }
}