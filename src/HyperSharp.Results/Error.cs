using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using OoLunar.HyperSharp.Results.Json;

namespace OoLunar.HyperSharp.Results
{
    [JsonConverter(typeof(ErrorJsonConverter))]
    public record Error
    {
        private static readonly Error[] _empty = Array.Empty<Error>();

        public string Message { get; init; }
        public IEnumerable<Error> Errors { get; init; }
        public Exception? Exception { get; init; }

        public Error()
        {
            Message = "<No error message provided>";
            Errors = _empty;
        }

        public Error(string message)
        {
            Message = message;
            Errors = _empty;
        }

        public Error(string message, Error error)
        {
            Message = message;
            Errors = Enumerable.Repeat(error, 1);
        }

        public Error(string message, IEnumerable<Error> errors)
        {
            Message = message;
            Errors = errors;
        }

        public Error(Exception exception)
        {
            Message = exception.Message;
            Exception = exception;
            Errors = _empty;
        }

        public Error(Exception exception, Error error)
        {
            Message = exception.Message;
            Exception = exception;
            Errors = Enumerable.Repeat(error, 1);
        }

        public Error(Exception exception, IEnumerable<Error> errors)
        {
            Message = exception.Message;
            Exception = exception;
            Errors = errors;
        }

        public Error(string message, Exception exception)
        {
            Message = message;
            Exception = exception;
            Errors = _empty;
        }

        public Error(string message, Exception exception, Error error)
        {
            Message = message;
            Exception = exception;
            Errors = Enumerable.Repeat(error, 1);
        }

        public Error(string message, Exception exception, IEnumerable<Error> errors)
        {
            Message = message;
            Exception = exception;
            Errors = errors;
        }
    }
}
