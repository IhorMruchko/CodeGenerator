using CodeGenerator.WPF.Resources.Enums;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CodeGenerator.WPF.Resources.TemplateSelectors;

public class ProjectTemplateSelector: DataTemplateSelector
{
    public DataTemplate? ProjectListViewTemplate { get; set; }

    public DataTemplate? ProjectGridViewTemplate { get; set; }
    
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item is not ProjectViewModel pvm) return null;
        
        switch (pvm.Layout)
        {
            case ProjectViewLayout.LIST:
                return ProjectListViewTemplate;
            case ProjectViewLayout.GRID:
                return ProjectGridViewTemplate;
            default:
                return null;
        }
        
    }
}
