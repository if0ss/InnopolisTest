using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Domain;

namespace Test.Application.Products.Commands.Add
{
    public class AddProductHandler : IRequestHandler<AddProduct, IActionResult>
    {
        private readonly IAppDbContext _dbContext;

        public AddProductHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Handle(AddProduct request, CancellationToken cancellationToken)
        {

                if (request is null)
                    return new BadRequestObjectResult("Request is null");

                var entity = new Product
                {
                    Description = request.Description,
                    Name = request.Name,
                    Okei = await _dbContext.Okei.FirstOrDefaultAsync(e => e.Id == request.OkeiId, cancellationToken),
                    UnitPrice = request.UnitPrice
                };

                await _dbContext.Products.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new OkResult();
        }
    }
}