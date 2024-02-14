using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Dtos
{
    public class AttachedProductDto
    {
        public int MainProductId { get; private set; }
        public int AttachedProductId { get; private set; }

        public AttachedProductDto()
        {
            
        }
        public AttachedProductDto(ProductDto mainProduct,ProductDto attachedProduct )
        {
            MainProductId = mainProduct.Id;
            AttachedProductId = attachedProduct.Id;
        }
    }
}
