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
using System.Text;

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

    public string Namespace { get; init; } = "Generation";

    public ItemsObservableCollection<GenerationElementViewModel> Items { get; set; } = new();

    public CommandGenerationElementViewModel(CommandModel model)
    {
        Item = model;
        Items = new(model.Items.Select<RequestGenerationItem, GenerationElementViewModel>(i =>
        {
            if (i is OverloadModel om)
                return new OverloadViewModel() { Model = om};
            return new InnerCommandViewModel((CommandModel)i);
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
            AttributesGeneration = GenerateAttributes(0),
            FluentApiGeneration = ""
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, preview });
    }

    protected override void Generate(object? parameter = null)
    {
        if (parameter
           .ToParser()
           .Parse(out MainWindow mv)
           .Parse(out ProjectElementsViewModel pevm)
           .Failed) return;

        var selectTypeDialog = new SelectTypeDialogViewModel();

        selectTypeDialog.DialogSuccess += () =>
        {
            Generate(pevm.Project.Directory);
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

        File.WriteAllText(path, GenerateAttributes(0));
    }

    protected override void Open(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse<MainWindow>(out var mv)
            .Failed) return;

        mv.ChangeContent(new InnerElementsViewModel(Item)
        {
            Source = Item,
            Title = Item.Class,
            Items = Items,
            
        });
    }

    public override string GenerateAttributes(int tabIndex)
    {
        return $@"using FluentRequests.Lib.Attributes.RoutingAttributes;

namespace {Namespace};

[Command(""{Item.Command}"")]
[Help(""{Item.Help}"")]
public class {Item.Class}
{{
{GenerateOverloads(tabIndex+1)}
}}
";
    }

    public override string GenerateFluentApi()
    {
        return "";
    }

    private string GenerateOverloads(int tabIndex)
    {
        var overloads = Items.Where(i => i is OverloadViewModel);
        var innerCommands = Items.Where(i => i is InnerCommandViewModel);
        
        if (!overloads.Any() && !innerCommands.Any())
        {
            return @$"{new('\t', tabIndex)}[Overload]
{new('\t', tabIndex)}[Help(""Empty overload"")]
{new('\t', tabIndex)}public static string EmptyOverload()
{new('\t', tabIndex)}{{
{new('\t', tabIndex + 1)}return typeof({Item.Class}).ToString();
{new('\t', tabIndex)}}}";
        }

        var result = new StringBuilder();
        if (overloads.Any())
        {
            foreach(var overload in overloads)
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
