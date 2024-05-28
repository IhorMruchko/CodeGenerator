using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.Views;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectElementsViewModel: ViewModel
{
    public Project Project { get; init; }

    public string Title
    {
        get => Project.Title;
        set
        {
            Project.Title = value;
            OnPropertyChanged();
        }
    }

    public ItemsObservableCollection<GenerationElementViewModel> Items { get; set; } = new();

    public RelayedCommand AddElementCommand => new(AddElement);

    private void AddElement(object? parameter = null) 
    {
        if (parameter
            .ToParser()
            .Parse<MainWindow>(out var mv)
            .Failed) return;

        var dialog = new CommandGenerationDialogViewModel();

        Commands.OpenDialogCommand.Execute(new object[] { mv, dialog });

        dialog.DialogSuccess += () =>
        {
            Items.Add(new CommandGenerationElementViewModel(dialog.Item));
            Project.Items.Add(dialog.Item);
        };
    }
}
