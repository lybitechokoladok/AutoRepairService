using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public string? Description { get; set; }

    public string? MainImagePath { get; set; }

    public bool IsActive { get; set; }

    public int? ManufacturerId { get; set; }

    public Manufacturer? Manufacturer { get; set; }

    public ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();

    public ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    public ICollection<Product> AttachedProducts { get; set; } = new List<Product>();

    public ICollection<Product> MainProducts { get; set; } = new List<Product>();
}
