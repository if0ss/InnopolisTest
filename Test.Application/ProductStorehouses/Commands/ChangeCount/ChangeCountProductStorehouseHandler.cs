using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;

namespace Test.Application.ProductStorehouses.Commands.ChangeCount
{
    public class ChangeCountProductStorehouseHandler : IRequestHandler<ChangeCountProductStorehouse, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        public ChangeCountProductStorehouseHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Handle(ChangeCountProductStorehouse request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestResponse("Request is null");

            var entity = await _dbContext.ProductStorehouses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity is null)
                return new NotFoundResponse($"Товар с идентификатором {request.Id} не найден");

            var count = entity.Count + request.Count.GetValueOrDefault(0);

            if(count < 0)
                return new BadRequestResponse($"Количество товара на складе меньше вычитаемого");

            entity.Count = count;

            _dbContext.ProductStorehouses.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();

        }
    }
}