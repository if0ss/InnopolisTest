using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;
using Test.Domain;

namespace Test.Application.ProductStorehouses.Commands.Add
{
    public class AddProductStorehouseHandler : IRequestHandler<AddProductStorehouse, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddProductStorehouseHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(AddProductStorehouse request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestResponse("Request is null");

            var entity = _mapper.Map<ProductStorehouse>(request);

            entity.Product = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == request.ProductId, cancellationToken);
            entity.Storehouse = await _dbContext.Storehouses.FirstOrDefaultAsync(e => e.Id == request.StorehouseId, cancellationToken);

            await _dbContext.ProductStorehouses.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}