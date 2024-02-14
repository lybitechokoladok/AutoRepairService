using AutoRepairService.Domain.Core.Primitives.Result;
using AutoRepairService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Dtos
{
    public class ClientDto
    {
        public int Id { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set;}
        public string Patronomic { get;  set; }
        public DateTime Birthday { get;  set; }
        public DateTime RegistrationDate { get;  set; }
        public Email Email { get;  set; }
        public Phone Phone { get;  set; }
        public char GenderCode { get;  set; }
        public string PhotoPath { get;  set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<ServiceDto> Services { get; set; }
    }
}
