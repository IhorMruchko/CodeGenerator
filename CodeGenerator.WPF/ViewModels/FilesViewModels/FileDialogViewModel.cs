using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.FilesViewModels;

public class FileDialogViewModel : DialogViewModel
{
    private string? _fileName;

    private string? _fileExtension;

    public string? FileExtension
    {
        get => _fileExtension;
        set
        {
            _fileExtension = value;
            OnPropertyChanged();
        }
    }

    public string? FileName
    {
        get => _fileName;
        set
        {
            _fileName = value;
            OnPropertyChanged();
        }
    }

    public string? Directory { get; set; }
}
