using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class ServicePhoto
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public string PhotoPath { get; set; } = null!;

    public Service Service { get; set; } = null!;
}
