using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.Resources.CustomControllers;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.ViewModels.FilesViewModels;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;
using CodeGenerator.WPF.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace CodeGenerator.WPF.Resources;

public static class Commands
{
    public static RelayedCommand ExitApplication => new(Exit);

    public static RelayedCommand CloseWindowCommand => new(CloseWindow);

    public static RelayedCommand ResizeWindowCommand => new(ResizeWindow);

    public static RelayedCommand MinimizeWindowCommand => new(MinimizeWindow);

    public static RelayedCommand AddFileCommand => new(AddFile);

    private static void Exit(object? parameter = null)
        => Environment.Exit(0);

    private static void CloseWindow(object? parameter = null)
    {
        if (parameter is not MainWindow mv) return;

        mv.Close();
    }

    private static void ResizeWindow(object? parameter = null)
    {
        if (parameter is not object[] parameters
            || parameters.Length != 2
            || parameters[0] is not MainWindow mv
            || parameters[1] is not IconButton ib) return;

        if (mv.WindowState == WindowState.Maximized)
        {
            mv.WindowState = WindowState.Normal;
            ib.Icon = (ImageSource)Application.Current.FindResource("FullScreenIcon");
        }
        else
        {
            mv.WindowState = WindowState.Maximized;
            ib.Icon = (ImageSource)Application.Current.FindResource("NormalScreenIcon");
        }
    }

    private static void MinimizeWindow(object? parameter = null)
    {
        if (parameter is not MainWindow mv) return;
        mv.WindowState = WindowState.Minimized;
    }

    private static void AddFile(object? parameter=null)
    {
        if (!parameter.ToParser()
            .Parse<MainWindow>(out var mv)
            .Parse<string>(out var dir)
            .Parse<ProjectFilesViewModel>(out var pfvm)
            .CanParse) return;
        
        var createFileDialog = new FileDialogViewModel()
        {
            Directory = dir
        };

        createFileDialog.PropertyChanged += CreateFileDialog_PropertyChanged;
        mv.OpenDialogWindow(createFileDialog);
    }

    private static void CreateFileDialog_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (sender is not FileDialogViewModel fdvm
            || e.PropertyName != nameof(DialogViewModel.HasValue)
            || !fdvm.HasValue
            || fdvm.Directory is null
            || fdvm.FileName is null
            || fdvm.FileExtension is null
        ) return;

        File.Create(Path.Combine(fdvm.Directory, fdvm.FileName + fdvm.FileExtension));
    }
}
