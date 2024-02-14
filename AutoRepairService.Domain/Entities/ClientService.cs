using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class ClientService
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ServiceId { get; set; }

    public DateTime StartTime { get; set; }

    public string? Comment { get; set; }

    public Client Client { get; set; } = null!;

    public  ICollection<DocumentByService> DocumentByServices { get; set; } = new List<DocumentByService>();

    public  ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    public  Service Service { get; set; } = null!;
}
