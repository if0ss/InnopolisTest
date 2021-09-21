using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;
using Test.Domain;

namespace Test.Application.Products.Commands.Add
{
    /// <summary>
    /// Обработчик запроса 
    /// </summary>
    public class AddProductHandler : IRequestHandler<AddProduct, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        public readonly IMapper _mapper;

        public AddProductHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(AddProduct request, CancellationToken cancellationToken)
        {

            if (request is null)
                return new BadRequestObjectResult(new BadRequestResponse("Request is null"));

            var entity = _mapper.Map<Product>(request);

            entity.Okei = await _dbContext.Okei.FirstOrDefaultAsync(e => e.Id == request.OkeiId, cancellationToken);

            await _dbContext.Products.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}