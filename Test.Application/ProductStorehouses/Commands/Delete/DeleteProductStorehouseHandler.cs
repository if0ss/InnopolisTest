using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;

namespace Test.Application.ProductStorehouses.Commands.Delete
{
    public class DeleteProductStorehouseHandler : IRequestHandler<DeleteProductStorehouse, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        public DeleteProductStorehouseHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Handle(DeleteProductStorehouse request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestResponse("Request is null");

            var entity = await _dbContext.ProductStorehouses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity is null)
                return new NotFoundResponse($"Товар на складе с идентификатором {request.Id} не найден");

            _dbContext.ProductStorehouses.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}