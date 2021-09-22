using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.Products.Dto;

namespace Test.Application.Products.Queries.GetList
{
    /// <summary>
    /// Обработчик запроса получения списка продуктов
    /// </summary>
    public class GetProductsListHandler : IRequestHandler<GetProductsList, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductsListHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetProductsList request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request?.NameContains))
                query = query.Where(e => e.Name.Contains(request.NameContains));

            if (request != null && request.UnitPriceFrom.HasValue)
                query = query.Where(e => e.UnitPrice >= request.UnitPriceFrom);

            if (request != null && request.UnitPriceTo.HasValue)
                query = query.Where(e => e.UnitPrice <= request.UnitPriceTo);
            
            return new OkObjectResult(await query.ProjectTo<ProductListDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
        }
    }
}