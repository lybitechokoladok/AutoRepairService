using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class HistoryEnter
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public bool Access { get; set; }

    public User User { get; set; } = null!;
}
