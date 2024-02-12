using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Models
{
    public class Tag
    {
        public Tag()
        {
            
        }
        public Tag(int id, string title, string color)
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
