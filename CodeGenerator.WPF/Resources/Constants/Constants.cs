using CodeGenerator.WPF.Resources.Enums;
using System;
using System.IO;
using System.Windows;

namespace CodeGenerator.WPF.Resources.Constants;

public static class Constants
{
    public static readonly string PROJ_FILE_CONTENT = "<Project Sdk=\"Microsoft.NET.Sdk\">\n\n  <PropertyGroup>\n    <OutputType>Exe</OutputType>\n    <TargetFramework>net6.0</TargetFramework>\n    <ImplicitUsings>enable</ImplicitUsings>\n    <Nullable>enable</Nullable>\n  </PropertyGroup>\n\n    <ItemGroup>\n    <PackageReference Include=\"FluentRequests.Lib\" Version=\"1.0.4\" />\n  </ItemGroup>\n\n</Project>";

    public static readonly string ENTRY_POINT = "using FluentRequests.Lib.Extensions;\nusing FluentRequests.Lib.Registering;\n\nvar register = RegistrationManager.RoutingRegister.AddFromAssembly<Program>();\n\nwhile(true)\n{\n    var message = register.Execute(Console.ReadLine()?.Split() ?? Array.Empty<string>());\n    if (message.Length > 0)\n    {\n        Console.WriteLine(message);\n    }\n}";

    public static readonly string APPLICATION_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public static readonly string APPLICATION_NAME = "Code Generator";

    public static readonly string APPLICATION_PATH = Path.Combine(APPLICATION_DIRECTORY, APPLICATION_NAME);

    public static readonly string PROJECTS_FILENAME = "Projects.json";

    public static ProjectViewLayout DEFAULT_PROJECT_LAYOUT = ProjectViewLayout.LIST;

#if RELEASE
    public static readonly Visibility COMPONENT_VISIBILITY = Visibility.Collapsed;
#else
    public static readonly Visibility COMPONENT_VISIBILITY = Visibility.Visible;
#endif
}
