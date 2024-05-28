using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.Views;
using System.Linq;
using System.Windows.Forms;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class InnerElementsViewModel : ViewModel
{
    public string? Title { get; init; }

    public CommandModel Source { get; init; }

    public ItemsObservableCollection<GenerationElementViewModel> Items { get; set; } = new();

    public InnerElementsViewModel(CommandModel source)
    {
        Title = source.Class;
        Source = source;
        Items = new(Source.Items.Select<RequestGenerationItem, GenerationElementViewModel>(i =>
        {
            if (i is OverloadModel om)
                return new OverloadViewModel() { Model = om };
            return new InnerCommandViewModel((CommandModel)i);
        }));
        Items.CollectionChanged += (_, _) => OnPropertyChanged(nameof(Source.Class));
        Items.ItemPropertyChanged += (_, _) => OnPropertyChanged(nameof(Source.Class));
    }

    public RelayedCommand AddOverloadCommand => new(AddOverload);

    public RelayedCommand AddInnerCommand => new(AddInner);

    private void AddOverload(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var dialog = new OverloadDialogViewModel();

        dialog.DialogSuccess += () =>
        {
            Source.Items.Add(dialog.Item);
            Items.Add(new OverloadViewModel()
            {
                Model = dialog.Item
            });
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, dialog });
    }

    private void AddInner(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var dialog = new CommandGenerationDialogViewModel();

        dialog.DialogSuccess += () =>
        {
            
            Source.Items.Add(dialog.Item);
            Items.Add(new InnerCommandViewModel(dialog.Item));
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, dialog });
    }
}
