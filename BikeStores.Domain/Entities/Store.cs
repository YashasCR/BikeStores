using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
