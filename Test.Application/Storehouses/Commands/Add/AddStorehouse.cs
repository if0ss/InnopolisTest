using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.Storehouses.Commands.Add
{
    public class AddStorehouse : IRequest<IActionResult>
    {
        public string Address { get; set; }

        public string Phone { get; set; }
    }
}