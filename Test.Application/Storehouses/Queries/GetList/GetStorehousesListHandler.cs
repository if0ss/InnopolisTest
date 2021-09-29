using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.Storehouses.Dto;

namespace Test.Application.Storehouses.Queries.GetList
{
    public class GetStorehousesListtHandler : IRequestHandler<GetStorehousesList, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetStorehousesListtHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetStorehousesList request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Storehouses.AsQueryable();

            if (!string.IsNullOrEmpty(request?.Address))
                query = query.Where(e => e.Address == request.Address);

            if (!string.IsNullOrEmpty(request.Phone))
                query = query.Where(e => e.Phone == request.Phone);
            
            return new OkObjectResult(await query.ProjectTo<StorehouseListDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
        }
    }
}