using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;
using CodeGenerator.WPF.Views;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class OverloadViewModel : GenerationElementViewModel
{
    public OverloadModel Model { get; set; }

    public string MethodContent
    {
        get => Model.Help;
        set
        {
            Model.MethodContent = value;
            OnPropertyChanged();
        }

    }

    public string MethodName
    {
        get => Model.MethodName;
        set
        {
            Model.MethodName = value;
            OnPropertyChanged();
        }

    }

    public string Help 
    { 
        get => Model.Help; 
        set
        {
            Model.Help = value;
            OnPropertyChanged();
        }
    
    }

    public override void Generate(string dir)
    {
        throw new System.NotImplementedException();
    }

    public override string GenerateAttributes(int tabIndex)
    {
        return @$"{new('\t', tabIndex)}[Overload]
{new('\t', tabIndex)}[Help(""{Model.Help}"")]
{new('\t', tabIndex)}public static string {Model.MethodName ?? "Empty"}()
{new('\t', tabIndex)}{{
{new('\t', tabIndex + 1)}{Model.MethodContent ?? "return string.Empty"};
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
            ConfirmationText = $"Are you sure you want to delete this ({Model}) overload?"
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
        var editDialog = new OverloadDialogViewModel()
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
        throw new System.NotImplementedException();
    }

    protected override void Preview(object? parameter = null)
    {
        throw new System.NotImplementedException();
    }
}
