using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeGenerator.WPF.Resources.CustomControllers;

public class IconButton : Button, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? callerName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
    
    public static readonly DependencyProperty ImageButtonProperty = DependencyProperty.Register(
        "Image",
        typeof(ImageSource),
        typeof(IconButton),
        new UIPropertyMetadata(null)
    );

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        "CornerRadius",
        typeof(CornerRadius),
        typeof(IconButton),
        new UIPropertyMetadata(new CornerRadius(0))
    );

    static IconButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
    }

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(ImageButtonProperty);
        set 
        {
            SetValue(ImageButtonProperty, value);
            OnPropertyChanged();
        }
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
}
