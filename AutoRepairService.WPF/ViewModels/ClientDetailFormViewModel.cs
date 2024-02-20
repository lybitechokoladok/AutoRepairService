using AutoRepairService.Domain.Entities;
using AutoRepairService.WPF.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.ViewModels
{
    public partial class ClientDetailFormViewModel : ObservableValidator
    {
        private const string EmailRegexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        private readonly SelectedClientStore _clientStore;
        public Client Client { get; set; }

        [Required]
        [ObservableProperty]
        private int id;

        [Required]
        [MaxLength(50)]
        [ObservableProperty]
        private string firstName;

        [Required]
        [MaxLength(50)]
        [ObservableProperty]
        private string lastName;

        [Required]
        [MaxLength(50)]
        [AllowNull]
        [ObservableProperty]
        private string patronomic;

        [AllowNull]
        [ObservableProperty]
        private DateTime birthday;

        [Required]
        [ObservableProperty]
        private DateTime registrationDate;

        [AllowNull]
        [MaxLength(255)]
        [RegularExpression(EmailRegexPattern)]
        [ObservableProperty]
        private string email;

        [Required]
        [MaxLength(20)]
        [ObservableProperty]
        private string phone;

        [Required]
        [ObservableProperty]
        private string gender;

        [AllowNull]
        [MaxLength(1000)]
        [ObservableProperty]
        private string imagePath;

        public IAsyncRelayCommand UpdateClientCommad { get; }
        public IRelayCommand CloseClientDetailCommand { get; }

        public ClientDetailFormViewModel(SelectedClientStore clientStore)
        {
            _clientStore = clientStore;

            if(clientStore.SelectedClient == null) Client = new Client();
            else Client = clientStore.SelectedClient;
        }
    }
}
