using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;
using CodeGenerator.WPF.Views;
using System.IO;
using System.Linq;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class CommandGenerationElementViewModel: GenerationElementViewModel
{
    public CommandModel Item { get; set; } = new();

    public string Command 
    {
        get => Item.Command;
        set
        {
            Item.Command = value;
            OnPropertyChanged();
        }
    }

    public string Class
    {
        get => Item.Class;
        set
        {
            Item.Class = value;
            OnPropertyChanged();
        }
    }

    public string? Help
    {
        get => Item.Help;
        set
        {
            Item.Help = value;
            OnPropertyChanged();
        }
    }

    public ItemsObservableCollection<CommandInnerItemViewModel> Items { get; set; } = new();

    public CommandGenerationElementViewModel(CommandModel model)
    {
        Item = model;
        Items = new(model.Items.Select<CommandInnerItemModel, CommandInnerItemViewModel>(i =>
        {
            if (i is OverloadModel om)
                return new OverloadViewModel() { Model = om};
            return new InnerCommandViewModel() { Model = (InnerCommandModel)i } ;
        }));
        Items.CollectionChanged += (_, _) => OnPropertyChanged(nameof(Help));
        Items.ItemPropertyChanged += (_, _) => OnPropertyChanged(nameof(Help));
    }

    protected override void Preview(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var preview = new PreviewGenerationDialogViewModel()
        {
            AttributesGeneration = Item.GenerateAttributes(),
            FluentApiGeneration = Item.GenerateFluent()
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, preview });
    }

    protected override void Generate(object? parameter = null)
    {
        if (parameter
           .ToParser()
           .Parse(out MainWindow mv)
           .Failed) return;

        var selectTypeDialog = new SelectTypeDialogViewModel();

        selectTypeDialog.DialogSuccess += () =>
        {
            Generate(selectTypeDialog.Directory);
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, selectTypeDialog });
    }

    protected override void Edit(object? parameter = null)
    {
        if (parameter
           .ToParser()
           .Parse(out MainWindow mv)
           .Parse(out ProjectElementsViewModel pevm)
           .Failed) return;

        var editDialog = new CommandGenerationDialogViewModel()
        {
            Item = Item.Copy(),
        };

        editDialog.DialogSuccess += () =>
        {
            this.CopyFrom(editDialog.Item);
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, editDialog });
    }

    protected override void Delete(object? parameter = null)
    {
        if (parameter
           .ToParser()
           .Parse(out MainWindow mv)
           .Parse(out ProjectElementsViewModel pevm)
           .Failed) return;

        var confirmationDialog = new ConfirmDialogViewModel()
        {
            ConfirmationText = $"Are you sure you want to delete {Command} command?"
        };

        confirmationDialog.DialogSuccess += () =>
        {
            pevm.Project.Items.Remove(Item);
            pevm.Items.Remove(this);
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, confirmationDialog });
    }

    public override void Generate(string dir)
    {
        if (!Directory.Exists(dir)) return;
        var path = Path.Combine(dir, Class + ".cs");

        Item.NamespaceDeclaration = Path.GetFileName(dir);
        File.WriteAllText(path, Item.GenerateAttributes());
    }

    protected override void Open(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse<MainWindow>(out var mv)
            .Failed) return;

        mv.ChangeContent(new InnerElementsViewModel()
        {
            Source = Item,
            Title = Item.Class,
            Items = Items
        });
    }
}
