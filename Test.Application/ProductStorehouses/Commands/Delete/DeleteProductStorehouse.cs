using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ProductStorehouses.Commands.Delete
{
    public class DeleteProductStorehouse : IRequest<IActionResult>
    {
        public DeleteProductStorehouse(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}