using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
using AutoRepairService.WPF.Services;
using AutoRepairService.WPF.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AutoRepairService.WPF.ViewModels
{
    public partial class ClientDetailFormViewModel : ObservableValidator
    {
        private readonly SelectedClientStore _clientStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly IClientRepository _clientRepository;

        [ObservableProperty]
        private bool isMen;

        [ObservableProperty]
        private bool isWomen;

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

        [MaxLength(50)]
        [AllowNull]
        [ObservableProperty]
        private string patronomic;

        [AllowNull]
        [MaybeNull]
        [ObservableProperty]
        private DateTime? birthday;

        [Required]
        [ObservableProperty]
        private DateTime registrationDate;

        [AllowNull]
        [MaxLength(255)]
        [CustomValidation(typeof(ClientDetailFormViewModel), nameof(ValidateEmail))]
        [ObservableProperty]
        private string email;

        [Required]
        [MaxLength(20)]
        [Phone]
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
        public IRelayCommand CloseClientDetailFormCommand { get; }
        public IRelayCommand SetMenGenderCommand { get; }
        public IRelayCommand SetWomenGenderCommand { get; }

        public IRelayCommand SaveClientCommand { get; }

        public ClientDetailFormViewModel(
            SelectedClientStore selectedClientStore,
            ModalNavigationStore modalNavigationStore,
            IClientRepository clientRepository)
        {
            _clientStore = selectedClientStore;
            _modalNavigationStore = modalNavigationStore;
            _clientRepository = clientRepository;

            Birthday = DateTime.Now;
            RegistrationDate = DateTime.Now;

            if (selectedClientStore.SelectedClient != null) 
            {
                Id = selectedClientStore.SelectedClient.Id;
                FirstName = selectedClientStore.SelectedClient.FirstName;
                LastName = selectedClientStore.SelectedClient.LastName;
                Patronomic = selectedClientStore.SelectedClient.Patronymic;
                Birthday = selectedClientStore.SelectedClient.Birthday;
                Email = selectedClientStore.SelectedClient.Email;
                Phone = selectedClientStore.SelectedClient.Phone;
                Gender = selectedClientStore.SelectedClient.GenderCodeNavigation.Name;
                ImagePath = selectedClientStore.SelectedClient.PhotoPath;

            }

            if (Gender == "Мужчина")
                IsMen = true;
            else
                isWomen = true;

            CloseClientDetailFormCommand = new RelayCommand(Close);
            SetMenGenderCommand = new RelayCommand(SetMenGender);
            SetWomenGenderCommand = new RelayCommand(SetWomenGender);
            SaveClientCommand = new RelayCommand(SaveClient);
        }

        private void SaveClient()
        {

            string genderCode;
            if (Gender == "Мужчина")
                genderCode = "1";
            else
                genderCode = "2";

            var gender = new Gender()
            {
                Code = genderCode,
                Name = Gender,
            };

            var client = new Client() 
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Patronymic = Patronomic,
                Birthday=Birthday,
                RegistrationDate = RegistrationDate,
                Email = Email,
                Phone = Phone,
                GenderCode = genderCode,
                GenderCodeNavigation = gender,
                PhotoPath = ImagePath,
            };

            try
            {
                if (_clientStore.SelectedClient is not null)
                {
                    _clientRepository.Update(client);
                    _clientStore.SelectedClient = client;
                }
                else
                {
                    _clientRepository.Add(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetWomenGender()
        {
            IsMen = false;
            IsWomen = true;

            Gender = "Женщина";
        }

        private void SetMenGender()
        {
            IsMen = true;
            IsWomen = false;

            Gender = "Мужчина";
        }

        private void Close()
         => _modalNavigationStore.Close();

        public static ValidationResult ValidateEmail(string value)
        {
            MailAddress mailAddress = new MailAddress(value);
            bool isValid = string.IsNullOrEmpty(mailAddress.DisplayName);

            if (isValid)
                return ValidationResult.Success;

            return new("The email is not does not match example@mail.ru");
        }

        
    }
}
