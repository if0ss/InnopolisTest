using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;

namespace Test.Application.Products.Commands.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, IActionResult>
    {
        private readonly IAppDbContext _dbContext;

        public UpdateProductHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestObjectResult(new BadRequestResponse("Request is null"));

            var entity = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity is null)
                return new NotFoundResult();

            entity.Description = request.Description;
            entity.Name = request.Name;
            entity.Okei = await _dbContext.Okei.FirstOrDefaultAsync(e => e.Id == request.OkeiId, cancellationToken);
            entity.UnitPrice = request.UnitPrice;

            _dbContext.Products.Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}