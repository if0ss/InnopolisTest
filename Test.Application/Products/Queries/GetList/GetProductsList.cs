using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Products.Dto;

namespace Test.Application.Products.Queries.GetList
{
    /// <summary>
    /// Запрос получения списка продуктов
    /// </summary>
    public class GetProductsList : IRequest<IActionResult>
    {
       public string NameContains { get; set; }

       /// <summary>
       /// Цена за единицу "С"
       /// </summary>
       public decimal? UnitPriceFrom { get; set; }

       /// <summary>
       /// Цена за единицу "ДО"
       /// </summary>
       public decimal? UnitPriceTo { get; set; }

    }
}