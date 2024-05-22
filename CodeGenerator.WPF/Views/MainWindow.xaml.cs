using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels;
using CodeGenerator.WPF.ViewModels.BaseModels;
using System.Windows;

namespace CodeGenerator.WPF.Views;

public partial class MainWindow : Window
{    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    public RelayedCommand CloseDialog => new(CloseDialogWindow);

    public void CloseDialogWindow(object? parameter = null)
    {
        if (DialogContentControl.Content is DialogViewModel dvm)
            dvm.HasValue = parameter is bool param && param;

        DialogContentControl.Visibility = Visibility.Collapsed;
        DialogContentControl.Content = null;
    }

    public void OpenDialogWindow(DialogViewModel viewModel)
    {
        DialogContentControl.Visibility = Visibility.Visible;
        DialogContentControl.Content = viewModel;
    }

    public void ChangeContent(ViewModel viewModel)
    {
        ((MainWindowViewModel)DataContext).Slider.SelectedViewModel = viewModel;
    }

    private void DockPanel_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        if (e.LeftButton != System.Windows.Input.MouseButtonState.Pressed) return;
        if (WindowState == WindowState.Maximized)
        {
            var oldWidth = ActualWidth;
            Commands.ResizeWindowCommand.Execute(new object[]
            {
                this,
                ResizeButton
            });
            var newX = e.GetPosition(this).X;
            Left = newX - newX.Map(0, oldWidth, 0, ActualWidth);
            Top = e.GetPosition(this).Y - 20;
        }    
        DragMove();
    }
}
