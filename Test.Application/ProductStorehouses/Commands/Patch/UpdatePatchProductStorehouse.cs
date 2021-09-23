using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ProductStorehouses.Commands.Patch
{
    public class UpdatePatchProductStorehouse : IRequest<IActionResult>
    {
        public UpdatePatchProductStorehouse(JsonPatchDocument<UpdatePatchProductStorehouseDto> patch, int id)
        {
            Patch = patch;
            Id = id;
        }

        public JsonPatchDocument<UpdatePatchProductStorehouseDto> Patch { get; set; }
        public int Id { get; set; }
    }
}