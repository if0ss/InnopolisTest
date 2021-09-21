using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.Products.Dto;
using Test.Application.ResponsesDto;

namespace Test.Application.Products.Queries.GetById
{
    /// <summary>
    /// Обработчик запроса получения товара по id
    /// </summary>
    public class GetProductByIdHandler : IRequestHandler<GetProductById, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IActionResult> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestObjectResult(new BadRequestResponse("Request is null"));

            var dto = await _dbContext.Products.Where(e => e.Id == request.Id)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);

            return new OkObjectResult(dto);
        }
    }
}