using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Models
{
    public class Service
    {
        public Service()
        {
            
        }
        protected Service(int id, string title, double cost, int durationInSeconds, string? description, float? discount, string? mainImagePath)
        {
            Id = id;
            Title = title;
            Cost = cost;
            DurationInSeconds = durationInSeconds;
            Description = description;
            Discount = discount;
            MainImagePath = mainImagePath;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public double Cost { get; private set; }
        public int DurationInSeconds { get; private set; }
        public string? Description { get; private set; }
        public float? Discount { get; private set; }
        public string? MainImagePath { get; private set; }

        public static Service Create(int id, string title, double cost, int durationInSeconds, string? description, float? discount, string? mainImagePath)
        => new Service(id, title, cost, durationInSeconds, description, discount, mainImagePath);

        public IEnumerable<string> DocumentPaths { get; }
    }
}
