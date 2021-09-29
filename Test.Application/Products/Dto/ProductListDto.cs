namespace Test.Application.Products.Dto
{
    /// <summary>
    /// Списочный dto товара
    /// </summary>
    public class ProductListDto
    {
        public int Id { get; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

    }
}