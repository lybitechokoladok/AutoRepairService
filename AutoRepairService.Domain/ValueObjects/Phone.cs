using AutoRepairService.Domain.Core.Primitives;
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

        public Phone(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
