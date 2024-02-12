using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoRepairService.Domain.Core.Errors
{
    public static class DomainErrors
    {
        public static class Email
        {
            public static string NullOrEmpty => "Email.NullOrEmpty: The email is required.";

            public static string LongerThanAllowed => "Email.NullOrEmpty: The email is required.";

            public static string InvalidFormat => "Email.NullOrEmpty: The email is required.";
        }
    }
}
