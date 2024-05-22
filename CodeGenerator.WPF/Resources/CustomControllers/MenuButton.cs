using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeGenerator.WPF.Resources.CustomControllers;

public class MenuButton : Button
{
    public static readonly DependencyProperty ImageButtonProperty = DependencyProperty.Register(
        "Image", 
        typeof(ImageSource), 
        typeof(MenuButton), 
        new UIPropertyMetadata(null)
    );

    public static readonly DependencyProperty TextButtonProperty = DependencyProperty.Register(
        "Text", 
        typeof(string), 
        typeof(MenuButton), 
        new UIPropertyMetadata(null)
    );

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        "CornerRadius",
        typeof(CornerRadius),
        typeof(MenuButton),
        new UIPropertyMetadata(new CornerRadius(0))
    );

    static MenuButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));
    }

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(ImageButtonProperty);
        set => SetValue(ImageButtonProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextButtonProperty);
        set => SetValue(TextButtonProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
}
