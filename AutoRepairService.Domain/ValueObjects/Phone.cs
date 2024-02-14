using AutoRepairService.Domain.Core.Primitives;
using AutoRepairService.Domain.Core.Primitives.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public const int MaxLength = 20;
        public string Value { get; }

        private Phone(string value)
        {
            Value = value;
        }

        public static implicit operator string(Phone phone) => phone.Value;

        public static Result<Phone> Create(string phone)
            => Result.Create(phone, "")
                     .Map(p=> new Phone(p));
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
