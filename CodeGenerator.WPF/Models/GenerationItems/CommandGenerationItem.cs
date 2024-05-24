using System.Runtime.Serialization;

namespace CodeGenerator.WPF.Models.GenerationItems;

public class CommandGenerationItem: RequestGenerationItem
{
    private const string OVERLOAD =
        "\t[Overload]" +
        "\n\t[Help(\"TestOverload\")]" +
        "\n\tpublic static string Generated()" +
        "\n\t{{" +
        "\n\t\treturn typeof({2}).ToString();" +
        "\n\t}}";

    private const string GENERATION_TEXT_WITH_HELP =
        "[Command(\"{0}\")]" +
        "\n[Help(\"{1}\")]" +
        "\npublic class {2}" +
        "\n{{" +
        "\n" + OVERLOAD +
        "\n}}";
    
    private const string GENERATION_TEXT_API_WITH_HELP = "Command.BeginInit()" +
        "\n       .WithName(\"{0}\")" +
        "\n       .WithHelp(\"{1}\")" +
        "\n       .AddOverload(overload => overload.WithHelp(\"\")" +
        "\n                                        .WithBody(null)" +
        "\n                                        .EndInit())" +
        "\n       .EndInit();";

    [IgnoreDataMember]
    public string? NamespaceDeclaration;

    public string Class { get; set; } = "Class1";

    public string Command { get; set; } = "cmd";

    public override string Generate()
    {
        return string.Format(GENERATION_TEXT_WITH_HELP, Command, Help, Class);
    }

    public override string GenerateAttributes()
    {
        return Usings + Namespace + Content;
    }

    public override string GenerateFluent()
    {
        return string.Format(GENERATION_TEXT_API_WITH_HELP, Command, Help);
    }

    private string Content => string.Format(GENERATION_TEXT_WITH_HELP, Command, Help, Class);

    private static string Usings => "using FluentRequests.Lib.Attributes.RoutingAttributes;\n\n";

    private string Namespace =>
        NamespaceDeclaration is not null && NamespaceDeclaration.Length > 0
        ? $"namespace {NamespaceDeclaration};\n\n"
        : "namespace RoutingAttributes;\n\n";
}
