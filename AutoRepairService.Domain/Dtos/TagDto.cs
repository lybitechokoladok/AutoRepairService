using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Dtos
{
    public class TagDto
    {
        public TagDto()
        {
            
        }
        public TagDto(int id, string title, string color)
        {
            Id = id;
            Title = title;
            Color = color;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Color { get; private set; }
    }
}
