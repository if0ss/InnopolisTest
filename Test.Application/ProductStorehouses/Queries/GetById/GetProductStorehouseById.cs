using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ProductStorehouses.Queries.GetById
{
    public class GetProductStorehouseById : IRequest<IActionResult>
    {
        public GetProductStorehouseById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}