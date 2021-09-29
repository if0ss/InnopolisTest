using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ProductStorehouses.Commands.ChangeCount
{
    public class ChangeCountProductStorehouse : IRequest<IActionResult>
    {
        public int? Id { get; set; }
        public int? Count { get; set; }
    }
}