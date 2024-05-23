using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectFilesViewModel : ViewModel
{
    private Project? _source;

    private ObservableCollection<string> _files;
    
    public Project? Source 
    {
        get => _source;
        set
        {
            _source = value;
            FileNames = _source is null 
                ? new(Array.Empty<string>()) 
                : new(Directory.GetFiles(_source.Directory));
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> FileNames 
    { 
        get => _files; 
        set 
        {
            _files = value;
            OnPropertyChanged();
        } 
    }
}
