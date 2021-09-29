using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;

namespace Test.Application.ProductStorehouses.Commands.Patch
{
    public class UpdatePatchProductStorehouseHandler : IRequestHandler<UpdatePatchProductStorehouse, IActionResult>
    {
        private readonly IAppDbContext _dbContext;

        public UpdatePatchProductStorehouseHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Handle(UpdatePatchProductStorehouse request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductStorehouses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            var newValue = new UpdatePatchProductStorehouseDto();

            request.Patch.ApplyTo(newValue);
            
            var count = entity.Count + newValue.Count;

            if (count < 0)
                return new BadRequestResponse($"Количество товара на складе меньше вычитаемого");

            entity.Count = newValue.Count;

            _dbContext.ProductStorehouses.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}