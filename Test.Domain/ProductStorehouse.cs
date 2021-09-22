namespace Test.Domain
{
    /// <summary>
    /// Товар склада
    /// </summary>
    public class ProductStorehouse : IBaseEntity
    {
        public int Id { get; set; }
        
        public int? StorehouseId { get; set; }
        /// <summary>
        /// Склад
        /// </summary>
        public virtual Storehouse Storehouse { get; set; }

        public int? ProductId { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public uint Count { get; set; }
    }
}