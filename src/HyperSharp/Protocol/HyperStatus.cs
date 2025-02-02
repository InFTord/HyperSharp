using System;
using System.Diagnostics;
using System.Net;
using HyperSharp.SourceGenerators;

namespace OoLunar.HyperSharp.Protocol
{
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly partial record struct HyperStatus
    {
        public HttpStatusCode Code { get; init; }
        public HyperHeaderCollection Headers { get; init; }
        public object? Body { get; init; }

        public HyperStatus() : this(HttpStatusCode.InternalServerError, new HyperHeaderCollection(), null) { }

        [GenerateStatusCreation]
        public HyperStatus(HttpStatusCode code) : this(code, new HyperHeaderCollection(), null) { }

        [GenerateStatusCreation]
        public HyperStatus(HttpStatusCode code, object? body) : this(code, new HyperHeaderCollection(), body) { }

        [GenerateStatusCreation]
        public HyperStatus(HttpStatusCode code, HyperHeaderCollection headers) : this(code, headers, null) { }

        [GenerateStatusCreation]
        public HyperStatus(HttpStatusCode code, HyperHeaderCollection headers, object? body)
        {
            ArgumentNullException.ThrowIfNull(headers, nameof(headers));

            Code = code;
            Headers = headers;
            Body = body;
        }

        public override string ToString() => $"{(int)Code} {Code}, {Headers.Count:N0} header{(Headers.Count == 1 ? "" : "s")}";
    }
}
