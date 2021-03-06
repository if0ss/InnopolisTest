using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.Storehouses.Queries.GetById
{
    public class GetStorehouseById : IRequest<IActionResult>
    {
        public GetStorehouseById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}