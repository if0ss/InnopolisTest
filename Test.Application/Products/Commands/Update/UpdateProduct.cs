using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.Products.Commands.Update
{
    public class UpdateProduct : IRequest<IActionResult>
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public int? OkeiId { get; set; }

        /// <summary>
        /// Цена за единицу
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}