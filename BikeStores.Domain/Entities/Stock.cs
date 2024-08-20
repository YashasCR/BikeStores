using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities
{
    public class Stock
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
    }
}
