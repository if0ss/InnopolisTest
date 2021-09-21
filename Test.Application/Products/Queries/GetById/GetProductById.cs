using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Products.Dto;

namespace Test.Application.Products.Queries.GetById
{
    /// <summary>
    /// Запрос получения товара по id
    /// </summary>
    public class GetProductById : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}