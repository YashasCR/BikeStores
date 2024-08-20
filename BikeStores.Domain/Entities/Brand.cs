using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
