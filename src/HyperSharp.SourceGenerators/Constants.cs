namespace HyperSharp.SourceGenerators;

internal static class Constants
{
    public const string Attribute =
"""
// <auto-generated>
namespace HyperSharp.SourceGenerators;

[global::System.AttributeUsage(global::System.AttributeTargets.Constructor, Inherited = false, AllowMultiple = false)]
[global::System.CodeDom.Compiler.GeneratedCode("hypersharp-status-creation-generator", "0.1.0")]
internal sealed class GenerateStatusCreationAttribute : global::System.Attribute { }
""";

    public static readonly string[] HttpStatuses = System.Enum.GetNames(typeof(System.Net.HttpStatusCode));
}
