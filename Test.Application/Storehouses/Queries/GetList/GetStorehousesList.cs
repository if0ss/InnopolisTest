using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.Storehouses.Queries.GetList
{
    public class GetStorehousesList : IRequest<IActionResult>
    {
        public string Address { get; set; }

        public string Phone { get; set; }

    }
}