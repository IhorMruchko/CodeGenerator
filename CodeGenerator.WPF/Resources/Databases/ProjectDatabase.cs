using CodeGenerator.LIB.Utils.Connections;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;
using System.Linq;
using System;
using Const = CodeGenerator.WPF.Resources.Constants.Constants;
using CodeGenerator.LIB.Utils;

namespace CodeGenerator.WPF.Resources.Databases;

public static class ProjectDatabase
{
    private static readonly JsonIOService<Project[]> _connection = new(Const.APPLICATION_PATH, Const.PROJECTS_FILENAME);


    public static ItemsObservableCollection<ProjectViewModel> Read() 
        => new(_connection.TryRead(out var projects) ? projects?.Select(project => new ProjectViewModel(project)) ?? Array.Empty<ProjectViewModel>() : Array.Empty<ProjectViewModel>());

    public static void Save(Project[] source) 
        => BackgroundWorker.Worker.AddTask(() => _connection.Write(source));
}
