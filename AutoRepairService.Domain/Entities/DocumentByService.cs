using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class DocumentByService
{
    public int Id { get; set; }

    public int ClientServiceId { get; set; }

    public string DocumentPath { get; set; } = null!;

    public  ClientService ClientService { get; set; } = null!;
}
