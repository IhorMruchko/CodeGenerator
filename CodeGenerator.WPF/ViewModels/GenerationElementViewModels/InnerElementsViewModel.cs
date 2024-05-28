using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.Views;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class InnerElementsViewModel : ViewModel
{
    public string Title { get; init; }

    public CommandModel Source { get; init; }

    public ItemsObservableCollection<CommandInnerItemViewModel> Items { get; set; } = new();

    public RelayedCommand AddOverloadCommand => new(AddOverload);

    public RelayedCommand AddInnerCommand => new(AddInner);

    private void AddOverload(object? parameter = null)
    {
        Source.Items.Add(new OverloadModel());
        Items.Add(new OverloadViewModel());
    }

    private void AddInner(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var dialog = new InnerCommandGenerationDialogViewModel();

        dialog.DialogSuccess += () =>
        {
            
            Source.Items.Add(dialog.Source);
            Items.Add(new InnerCommandViewModel()
            {
                Model = dialog.Source
            });
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, dialog });
    }
}
