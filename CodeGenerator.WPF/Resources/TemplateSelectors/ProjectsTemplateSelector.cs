using CodeGenerator.WPF.Resources.Enums;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CodeGenerator.WPF.Resources.TemplateSelectors;

public class ProjectsTemplateSelector: DataTemplateSelector
{
    public DataTemplate? ProjectsListViewTemplate { get; set; }

    public DataTemplate? ProjectsGridViewTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item is not ProjectLayoutViewModel pvm) return null;

        switch (pvm.Layout)
        {
            case ProjectViewLayout.LIST:
                return ProjectsListViewTemplate;
            case ProjectViewLayout.GRID:
                return ProjectsGridViewTemplate;
            default:
                return null;
        }

    }
}
