using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Business.Entity
{
    public class ProductModel
    {
        public string Code { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
    }
}
