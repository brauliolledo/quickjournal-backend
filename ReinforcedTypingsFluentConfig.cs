using quickjournal_backend.Models;
using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Fluent;
using ConfigurationBuilder = Reinforced.Typings.Fluent.ConfigurationBuilder;

namespace quickjournal_backend;

public static class ReinforcedTypingsConfiguration
{
    public static void Configure(ConfigurationBuilder builder)
    {
        builder.Global(config => config.AutoOptionalProperties().UseModules().CamelCaseForProperties());
        builder.Substitute(typeof(System.Guid), new RtSimpleTypeName("string"));
        builder.Substitute(typeof(System.DateTime), new RtSimpleTypeName("string"));
        builder.ExportAsInterface<Entry>().WithAllProperties().AutoI(false);
    }
}