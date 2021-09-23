namespace Test.Application.ProductStorehouses.Dto
{
    public class ProductStorehouseDto
    {
        public int Id { get; set; }

        public int? StorehouseId { get; set; }
        public string StorehouseAddress { get; set; }


        public int? ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal? ProductUnitPrice { get; set; }

        public int? Count { get; set; }
    }
}