using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class ProductSale
{
    public int Id { get; set; }

    public DateTime SaleDate { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int? ClientServiceId { get; set; }

    public ClientService? ClientService { get; set; }

    public Product Product { get; set; } = null!;
}
