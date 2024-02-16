using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.ValueObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace AutoRepairService.WPF.ViewModels
{
    public partial class ClientListingItemViewModel : ObservableValidator
    {
        public Client Client { get; set; }
        public int Id => Client.Id;
        // public string Gender => Client.GenderCodeNavigation.Name ?? string.Empty;
        public string FullName => $"{Client.FirstName} {Client.LastName} {Client.Patronymic}";
        public DateOnly Birthday => DateOnly.FromDateTime(Client.Birthday.Value);
        public string Phone =>Client.Phone;
        public string Email => Client.Email;
        public DateTime CreationDate => Client.RegistrationDate;

        public DateTime LastVistitDate => Client.ClientServices.Last().StartTime;
        public int VisitCount => Client.ClientServices.Count();
        public List<Tag> Tags => Client.Tags.ToList();

        public ClientListingItemViewModel(Client client)
        {
            Client = client;
        }
    }
}
