using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.Views;
using System.Linq;
using System.Text;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class InnerCommandViewModel : GenerationElementViewModel
{
    public CommandModel Model { get; set; }

    public string Command
    {
        get => Model.Command;
        set
        {
            Model.Command = value;
            OnPropertyChanged();
        }
    }

    public string Class
    {
        get => Model.Class;
        set
        {
            Model.Class = value;
            OnPropertyChanged();
        }
    }

    public string? Help
    {
        get => Model.Help;
        set
        {
            Model.Help = value;
            OnPropertyChanged();
        }
    }

    public ItemsObservableCollection<GenerationElementViewModel> Items { get; set; } = new();

    public InnerCommandViewModel(CommandModel source)
    {
        Model = source;
        Items = new(Model.Items.Select<RequestGenerationItem, GenerationElementViewModel>(i =>
        {
            if (i is OverloadModel om)
                return new OverloadViewModel() { Model = om };
            return new InnerCommandViewModel((CommandModel)i);
        }));
        Items.CollectionChanged += (_, _) => OnPropertyChanged(nameof(Model.Class));
        Items.ItemPropertyChanged += (_, _) => OnPropertyChanged(nameof(Model.Class));
    }

    public override void Generate(string dir)
    {
        throw new System.NotImplementedException();
    }

    public override string GenerateAttributes(int tabIndex)
    {
        return $@"{new('\t', tabIndex)}[Command(""{Model.Command}"")]
{new('\t', tabIndex)}[Help(""{Model.Help}"")]
{new('\t', tabIndex)}public class {Model.Class}
{new('\t', tabIndex)}{{
{GenerateOverloads(tabIndex + 1)}
{new('\t', tabIndex)}}}";
    }

    public override string GenerateFluentApi()
    {
        throw new System.NotImplementedException();
    }

    protected override void Delete(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Parse(out InnerElementsViewModel ievm)
            .Failed) return;

        var confirmDialog = new ConfirmDialogViewModel()
        {
            ConfirmationText = $"Are you sure you want to delete this ({Model.Command}) inner Command?"
        };

        confirmDialog.DialogSuccess += () =>
        {
            ievm.Source.Items.Remove(Model);
            ievm.Items.Remove(this);
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, confirmDialog });
    }

    protected override void Edit(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var copy = Model.Copy();
        var editDialog = new CommandGenerationDialogViewModel()
        {
            Item = copy
        };

        editDialog.DialogSuccess += () =>
        {
            this.CopyFrom(editDialog.Item);
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, editDialog });
    }

    protected override void Generate(object? parameter = null)
    {
        throw new System.NotImplementedException();
    }

    protected override void Open(object? parameter = null)
    {
        if (parameter
           .ToParser()
           .Parse<MainWindow>(out var mv)
           .Failed) return;

        mv.ChangeContent(new InnerElementsViewModel(Model)
        {
            Source = Model,
            Title = Model.Class,
            Items = Items
        });
    }

    protected override void Preview(object? parameter = null)
    {
        throw new System.NotImplementedException();
    }

    private string GenerateOverloads(int tabIndex)
    {
        var overloads = Items.Where(i => i is OverloadViewModel);
        var innerCommands = Items.Where(i => i is InnerCommandViewModel);

        if (!overloads.Any() && !innerCommands.Any())
        {
            return @$"
{new('\t', tabIndex)}[Overload]
{new('\t', tabIndex)}[Help(""Empty overload"")]
{new('\t', tabIndex)}public static string EmptyOverload()
{new('\t', tabIndex)}{{
{new('\t', tabIndex + 1)}return typeof({Model.Class}).ToString();

{new('\t', tabIndex)}}}";
        }

        var result = new StringBuilder();
        if (overloads.Any())
        {
            foreach (var overload in overloads)
            {
                result.Append('\n').Append(overload.GenerateAttributes(tabIndex)).Append('\n');
            }
        }

        if (innerCommands.Any())
        {
            foreach (var command in innerCommands)
            {
                result.Append('\n').Append(command.GenerateAttributes(tabIndex)).Append('\n');
            }
        }
        return result.ToString();
    }
}
