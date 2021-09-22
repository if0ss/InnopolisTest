using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.ResponsesDto;
using Test.Domain;

namespace Test.Application.Storehouses.Commands.Update
{
    public class UpdateStorehouseHandler : IRequestHandler<UpdateStorehouse, IActionResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateStorehouseHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UpdateStorehouse request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new BadRequestObjectResult(new BadRequestResponse("Request is null"));

            var entity = await _dbContext.Storehouses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity is null)
                return new NotFoundResult();

            entity = _mapper.Map<Storehouse>(request);

            _dbContext.Storehouses.Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new OkResult();
        }
    }
}