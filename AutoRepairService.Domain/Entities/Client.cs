using System;
using System.Collections.Generic;

namespace AutoRepairService.Domain.Entities;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime? Birthday { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public string GenderCode { get; set; } = null!;

    public string? PhotoPath { get; set; }

    public  ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

    public  Gender GenderCodeNavigation { get; set; } = null!;

    public  ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
