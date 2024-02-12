using AutoRepairService.Domain.Core.Primitives.Result;
using AutoRepairService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Models
{
    public class Client
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public string Patronomic { get; private set; }
        public DateTime Birthday { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public char GenderCode { get; private set; }
        public string PhotoPath { get; private set; }

        public Client()
        {
            
        }
        protected Client(
            int id,
            string firstName,
            string lastName,
            string patronomic,
            DateTime birthday, 
            DateTime registrationDate,
            Email email,
            Phone phone, 
            char genderCode,
            string photoPath = default)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Patronomic = patronomic;
            Birthday = birthday;
            RegistrationDate = registrationDate;
            Email = email;
            Phone = phone;
            GenderCode = genderCode;
            PhotoPath = photoPath;
        }

        public static Client Create(
            int id,
            string firstName,
            string lastName,
            string patronomic,
            DateTime birthday,
            DateTime registrationDate,
            Email email,
            Phone phone,
            char genderCode,
            string photoPath
            )
        => new Client(id, firstName, lastName, patronomic, birthday, registrationDate, email, phone, genderCode, photoPath);

        public IEnumerable<Tag> Tags { get; }
        public IEnumerable<Service> Services { get; }
    }
}
