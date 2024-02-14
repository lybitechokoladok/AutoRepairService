using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Dtos
{
    public class ProductDto
    {
        public ProductDto()
        {
            
        }
        public ProductDto(int id, string title, string description, string mainImagePath, bool isActive, int manufacturerId)
        {
            Id = id;
            Title = title;
            Description = description;
            MainImagePath = mainImagePath;
            IsActive = isActive;
            ManufacturerId = manufacturerId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainImagePath { get; set; }
        public bool IsActive { get; set; }
        public int ManufacturerId { get; set; }
    }
}
