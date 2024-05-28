using CodeGenerator.LIB.Extensions;
using CodeGenerator.LIB.Generation;
using CodeGenerator.LIB.Utils;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.Resources.Constants;
using CodeGenerator.WPF.Resources.Enums;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.Views;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectViewModel : ViewModel
{
    private ProjectViewLayout _layout = Constants.DEFAULT_PROJECT_LAYOUT;
    
    public ProjectViewLayout Layout 
    {
        get => _layout;
        set
        {
            _layout = value;
            OnPropertyChanged();
        }
    }
    
    public Project Project { get; set; } = new Project();

    public string Title
    {
        get => Project.Title;
        set
        {
            Project.Title = value;
            OnPropertyChanged();
        }
    }

    public ItemsObservableCollection<GenerationElementViewModel> Items { get; set; }
   

    public ProjectViewModel(Project? source = null)
    {
        Project = source ?? new Project();
        Items = new(Project.Items.Select(item => new CommandGenerationElementViewModel(item)));
        Items.CollectionChanged += (_, _) => OnPropertyChanged(nameof(Title));
        Items.ItemPropertyChanged += (_, _) => OnPropertyChanged(nameof(Title));
    }

    public RelayedCommand OpenEditDialogCommand => new(OpenEditDialog);

    public RelayedCommand OpenProjectCommand => new(OpenProject);

    public RelayedCommand GenerateAllCommand => new(Generate);

    public RelayedCommand OpenInFileExporerCommand => new(OpenInFileExplorer, CanOpenInFileExplorer);

    public RelayedCommand RunCommand => new(Run);

    private void Run(object? parameter = null) 
    {
        Process.Start(new ProcessStartInfo("dotnet", $"run")
        {
            WorkingDirectory = Project.Directory,
        });
    }

    private void OpenEditDialog(object? parameter = null) 
    {
        if (parameter is not MainWindow mv) return;


        var copy = Project.Copy();
        var editDialog = new ProjectDialogViewModel(copy)
        {
            DialogTitle = "Edit project"
        };
        
        editDialog.DialogSuccess += () =>
        {
            this.CopyFrom(copy);
        };
        
        Commands.OpenDialogCommand.Execute(new object[] { mv, editDialog });

    }

    private void OpenProject(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        mv.ChangeContent(new ProjectElementsViewModel()
        {
            Project = Project,
            Items = Items
        });
    }

    private void Generate(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var selectTypeDialog = new SelectTypeDialogViewModel();

        selectTypeDialog.DialogSuccess += () =>
        {
            var filePath = Path.Combine(Project.Directory, "Program.cs");
            File.WriteAllText(filePath, Constants.ENTRY_POINT);
            foreach (var item in Items)
            {
                item.Generate(Project.Directory);
            }
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, selectTypeDialog });
    }

    public void OpenInFileExplorer(object? parameter)
    {
        Process.Start("explorer.exe", Project.Directory);
    }

    public bool CanOpenInFileExplorer(object? parameter)
    {
        return Directory.Exists(Project.Directory);
    }
}
