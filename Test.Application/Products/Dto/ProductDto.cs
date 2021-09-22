namespace Test.Application.Products.Dto
{
    /// <summary>
    /// Dto товара
    /// </summary>
    public class ProductDto
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

        public int? OkeiId { get; set; }
        public string OkeiName { get; set; }

        /// <summary>
        /// Цена за единицу
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}