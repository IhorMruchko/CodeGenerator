using System;
using System.IO;
using System.Windows;

namespace CodeGenerator.WPF.Resources.Constants;

public static class Constants
{
    public static readonly string APPLICATION_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public static readonly string APPLICATION_NAME = "Code Generator";

    public static readonly string APPLICATION_PATH = Path.Combine(APPLICATION_DIRECTORY, APPLICATION_NAME);

    public static readonly string PROJECTS_FILENAME = "Projects.json";

#if RELEASE
    public static readonly Visibility COMPONENT_VISIBILITY = Visibility.Collapsed;
#else
    public static readonly Visibility COMPONENT_VISIBILITY = Visibility.Visible;
#endif
}
