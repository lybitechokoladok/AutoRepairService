using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class ProductPhoto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string PhotoPath { get; set; } = null!;

    public Product Product { get; set; } = null!;
}
