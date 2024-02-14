using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime LastEnter { get; set; }

    public int RoleId { get; set; }

    public ICollection<HistoryEnter> HistoryEnters { get; set; } = new List<HistoryEnter>();

    public  Role Role { get; set; } = null!;
}
