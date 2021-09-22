using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ProductStorehouses.Queries.GetList
{
    public class GetProductStorehouseList : IRequest<IActionResult>
    {
        public int? StorehouseId { get; set; }

        public int? ProductId { get; set; }

        /// <summary>
        /// Признак наличия товара на складе
        /// true - товар в наличии
        /// false - закончившийся товар
        /// null - весь список
        /// </summary>
        public bool? IsExist { get; set; }
    }
}