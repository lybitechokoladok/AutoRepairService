using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Models
{
    public class AttachedProduct
    {
        public int MainProductId { get; private set; }
        public int AttachedProductId { get; private set; }

        public AttachedProduct()
        {
            
        }
        public AttachedProduct(Product mainProduct,Product attachedProduct )
        {
            MainProductId = mainProduct.Id;
            AttachedProductId = attachedProduct.Id;
        }
    }
}
