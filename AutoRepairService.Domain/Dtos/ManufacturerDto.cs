using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Dtos
{
    public class ManufacturerDto
    {
        public ManufacturerDto()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate{ get; set; }

        public ManufacturerDto(int id, string name, DateTime startDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
        }
    }
}
