using System.Collections.Generic;

namespace Test.Domain
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product : IBaseEntity
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
        public virtual Okei Okei { get; set; }

        /// <summary>
        /// Цена за единицу
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Склады
        /// </summary>
        public virtual IList<ProductStorehouse> Storehouses { get; set; }
    }
}