using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoRepairService.Domain.Core.Primitives.Result
{
    public class Result
    {
        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == string.Empty)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public string Error { get; }
        public static Result Success() => new Result(true, string.Empty);

        public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, string.Empty);

        public static Result<TValue> Create<TValue>(TValue value, string error)
            where TValue : class
            => value is null ? Failure<TValue>(error) : Success(value);

        public static Result Failure(string error) => new Result(false, error);

        public static Result<TValue> Failure<TValue>(string error) => new Result<TValue>(default!, false, error);

        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Success();
        }
    }
}
