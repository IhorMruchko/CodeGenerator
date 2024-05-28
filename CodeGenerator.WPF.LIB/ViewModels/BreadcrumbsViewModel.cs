using CodeGenerator.WPF.LIB.Models;
using System.Collections.Generic;

namespace CodeGenerator.WPF.LIB.ViewModels;



public class BreadcrumbsViewModel: ViewModel
{
    private readonly Queue<Breadcrumb> _path = new();
    
    public void ChangeViewModel(Breadcrumb breadcrumb)
    {
        _path.Enqueue(breadcrumb);
    }

   
}
