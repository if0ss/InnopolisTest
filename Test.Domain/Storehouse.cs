using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Domain
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Storehouse : IBaseEntity
    {
        public int Id { get; }
        
        public string Address { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        public virtual IList<ProductStorehouse> Products { get; set; }

    }
}