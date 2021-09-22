using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ProductStorehouses.Commands.Add
{
    public class AddProductStorehouse : IRequest<IActionResult>
    {
        public int? StorehouseId { get; set; }

        public int? ProductId { get; set; }
        
        public uint? Count { get; set; }
    }
}