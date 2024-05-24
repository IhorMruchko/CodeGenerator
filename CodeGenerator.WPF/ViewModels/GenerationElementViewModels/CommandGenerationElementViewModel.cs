using CodeGenerator.LIB.Extensions;
using CodeGenerator.LIB.Generation;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;
using CodeGenerator.WPF.Views;
using System.IO;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class CommandGenerationElementViewModel: GenerationElementViewModel
{
    public CommandGenerationItem Item { get; set; } = new();

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
            if (!Directory.Exists(selectTypeDialog.Directory)) return;
            var path = Path.Combine(selectTypeDialog.Directory, Class + ".cs");
          
            Item.NamespaceDeclaration = Path.GetFileName(selectTypeDialog.Directory);
            File.WriteAllText(path, Item.GenerateAttributes());

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
}
