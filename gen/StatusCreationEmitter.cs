using System.Collections.Generic;
using System.Text;

namespace HyperSharp.Generators;

internal static class StatusCreationEmitter
{
    public static string Emit(ConstructorModel model)
    {
        if (model.SkipGeneration)
        {
            return "";
        }

        StringBuilder builder = new();

        builder.Append(
$$"""
// <auto-generated/>
namespace {{model.EnclosingNamespace}};

partial {{model.EnclosingTypeKeyword}} {{model.EnclosingType}}
{

""");

        // skip processing parameters if we're dealing with zero additional parameters
        if (model.Parameters!.Count == 0)
        {
            foreach (string code in Constants.HttpStatuses)
            {
                builder.Append(
$$"""
    /// <summary>
    /// Creates a new instance with the status code <c>HttpStatusCode.{{code}}</c>.
    /// </summary>
    public static {{model.EnclosingType}} CreateFrom{{code}}()
        => new(global::System.Net.HttpStatusCode.{{code}});


""");
            }

            builder.Append('}');

            return builder.ToString();
        }

        StringBuilder parameterListBuilder = new();

        foreach (KeyValuePair<string, string> parameter in model.Parameters!)
        {
            parameterListBuilder.Append($"{parameter.Value} {parameter.Key},");
        }

        string parameterList = parameterListBuilder.ToString();
        // remove the last comma
        parameterList = parameterList.Remove(parameterList.Length - 1);

        StringBuilder parameterNameListBuilder = new();

        foreach (KeyValuePair<string, string> parameter in model.Parameters)
        {
            parameterNameListBuilder.Append($"{parameter.Key},");
        }

        string parameterNameList = parameterNameListBuilder.ToString();
        // remove the last comma
        parameterNameList = parameterNameList.Remove(parameterNameList.Length - 1);

        foreach (string code in Constants.HttpStatuses)
        {
            builder.Append(
$$"""
    /// <summary>
    /// Creates a new instance with the status code <c>HttpStatusCode.{{code}}</c>.
    /// </summary>
    public static {{model.EnclosingType}} CreateFrom{{code}}({{parameterList}})
        => new(global::System.Net.HttpStatusCode.{{code}}, {{parameterNameList}});


""");
        }

        builder.Append('}');

        return builder.ToString();
    }
}
