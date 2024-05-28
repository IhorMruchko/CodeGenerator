using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.Views;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public class InnerCommandViewModel : CommandInnerItemViewModel
{
    public InnerCommandModel Model { get; set; }


    public override void Generate(string dir)
    {
        throw new System.NotImplementedException();
    }

    public override string GenerateAttributes(int tabIndex)
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
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
