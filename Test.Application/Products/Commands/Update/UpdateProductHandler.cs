using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;
using Test.Domain;

namespace Test.Application.Products.Commands.Update
{
    /// <summary>
    /// Обработчик обновления товара
    /// </summary>
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        public readonly IMapper _mapper;

        public UpdateProductHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestObjectResult(new BadRequestResponse("Request is null"));

            var entity = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity is null)
                return new NotFoundResult();

            entity = _mapper.Map<Product>(request);

            entity.Okei = await _dbContext.Okei.FirstOrDefaultAsync(e => e.Id == request.OkeiId, cancellationToken);

            _dbContext.Products.Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}