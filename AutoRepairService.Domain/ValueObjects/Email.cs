using AutoRepairService.Domain.Core.Errors;
using AutoRepairService.Domain.Core.Primitives;
using AutoRepairService.Domain.Core.Primitives.Result;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int MaxLength = 256;

        private const string EmailRegexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        private static readonly Lazy<Regex> EmailFormatRegex =
            new Lazy<Regex>(() => new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));

        private Email(string value) => Value = value;

        public string Value { get; }

        public static implicit operator string(Email email) => email.Value;

        public static Result<Email> Create(string email) =>
            Result.Create(email, DomainErrors.Email.NullOrEmpty)
                .Ensure(e => !string.IsNullOrWhiteSpace(e), DomainErrors.Email.NullOrEmpty)
                .Ensure(e => e.Length <= MaxLength, DomainErrors.Email.LongerThanAllowed)
                .Ensure(e => EmailFormatRegex.Value.IsMatch(e), DomainErrors.Email.InvalidFormat)
                .Map(e => new Email(e));

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
