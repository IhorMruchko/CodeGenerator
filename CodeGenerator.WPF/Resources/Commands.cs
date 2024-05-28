using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.Resources.CustomControllers;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.Views;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Windows.Media;

namespace CodeGenerator.WPF.Resources;

public static class Commands
{
    public static RelayedCommand ExitApplication => new(Exit);

    public static RelayedCommand CloseWindowCommand => new(CloseWindow);

    public static RelayedCommand ResizeWindowCommand => new(ResizeWindow);

    public static RelayedCommand MinimizeWindowCommand => new(MinimizeWindow);

    public static RelayedCommand OpenDialogCommand => new(OpenDialog);

    public static RelayedCommand CloseDialogCommand => new(CloseDialog);

    public static RelayedCommand ProceedDialogCommand => new(ProceedDialog);

    public static RelayedCommand OpenDirectoryDialogCommand => new(OpenDirectoryDialog);

    private static void OpenDirectoryDialog(object? parameter)
    {
        if (parameter
            .ToParser()
            .Parse(out string dir)
            .Parse(out IDirectoryProvider prov)
            .Failed) return;
        var directoryDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            InitialDirectory = dir
        };

        if (directoryDialog.ShowDialog() != CommonFileDialogResult.Ok) return;
        prov.Directory = directoryDialog.FileName!;
    }

    private static void OpenDialog(object? parameter=null)
    {
        if (parameter.ToParser()
            .Parse(out MainWindow mv)
            .Parse(out DialogViewModel dvm)
            .Failed) return;

        mv.DialogContentControl.Content = dvm;
        mv.DialogContentControl.Visibility = Visibility.Visible;
    }

    private static void CloseDialog(object? parameter=null)
    {
        if (parameter.ToParser()
           .Parse(out MainWindow mv)
           .Failed) return;

        mv.DialogContentControl.Visibility = Visibility.Collapsed;
        mv.DialogContentControl.Content = null;
    }

    private static void ProceedDialog(object? parameter=null)
    {
        if (parameter.ToParser()
           .Parse(out MainWindow mv)
           .Parse(out DialogViewModel dvm)
           .Failed) return;

        mv.DialogContentControl.Visibility = Visibility.Collapsed;
        mv.DialogContentControl.Content = null;

        dvm.ConfirmDialog();
    }

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
}


