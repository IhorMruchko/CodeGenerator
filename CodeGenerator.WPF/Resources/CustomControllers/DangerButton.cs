using System.Windows;

namespace CodeGenerator.WPF.Resources.CustomControllers;

public class DangerButton : IconButton
{
    static DangerButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DangerButton), new FrameworkPropertyMetadata(typeof(DangerButton)));
    }
}
