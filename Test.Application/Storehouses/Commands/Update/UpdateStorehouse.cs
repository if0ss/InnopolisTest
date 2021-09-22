using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.Storehouses.Commands.Update
{
    public class UpdateStorehouse : IRequest<IActionResult>
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }
    }
}