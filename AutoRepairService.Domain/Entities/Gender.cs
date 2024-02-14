using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class Gender
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public  ICollection<Client> Clients { get; set; } = new List<Client>();
}
