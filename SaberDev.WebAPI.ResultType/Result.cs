using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaberDev.WebAPI.ResultType
{
    public readonly struct Result<TValue, TError>
    {
        private readonly TValue? _value;
        private readonly TError? _error;

        public bool IsError { get; }
        public bool IsSuccess => !IsError;

        public Result(TValue value)
        {
            _value = value;
            _error = default;
            IsError = false;
        }

        public Result(TError error)
        {
            _value = default;
            _error = error;
            IsError = true;
        }

        public static implicit operator Result<TValue, TError>(TValue value) => new(value);

        public static implicit operator Result<TValue, TError>(TError error) => new(error);

        public TRsult Match<TRsult>(
            Func<TValue, TRsult> success, 
            Func<TError, TRsult> failure) => 
                IsError ? failure(_error!) : success(_value!);
    }
}