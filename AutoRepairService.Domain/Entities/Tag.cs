using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Color { get; set; } = null!;

    public ICollection<Client> Clients { get; set; } = new List<Client>();
}
