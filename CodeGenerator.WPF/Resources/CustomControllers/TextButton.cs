using System.Windows;
using System.Windows.Controls;

namespace CodeGenerator.WPF.Resources.CustomControllers;

public class TextButton : Button
{
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        "CornerRadius",
        typeof(CornerRadius),
        typeof(TextButton),
        new UIPropertyMetadata(new CornerRadius(0))
    );

    static TextButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TextButton), new FrameworkPropertyMetadata(typeof(TextButton)));
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
}
