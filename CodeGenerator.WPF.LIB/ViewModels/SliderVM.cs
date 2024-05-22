using CodeGenerator.WPF.LIB.Commands;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Diagnostics;

namespace CodeGenerator.WPF.LIB.ViewModels;

public class SliderVM : ViewModel
{
    private ViewModel? _selectedViewModel;

    protected ObservableCollection<ViewModel> ModelList { get; set; } = new();

    protected int CurrentItem { get; set; } = 0;

    public ViewModel? SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            _selectedViewModel = value;
            OnPropertyChanged();
        }
    }

    public SliderVM AddNext(ViewModel nextViewModel)
    {
        if (_selectedViewModel is null)
            SelectedViewModel = nextViewModel;

        ModelList.Add(nextViewModel);
        return this;
    }

    public SliderVM AddPrevious(ViewModel previousViewModel)
    {
        if (_selectedViewModel is null)
            SelectedViewModel = previousViewModel;

        ModelList.Insert(0, previousViewModel);
        return this;
    }

    public RelayedCommand SelectNextCommand => new(SelectNext, CanSelectNext);

    public RelayedCommand SelectPreviousCommand => new(SelectPrevious, CanSelectPrevious);

    public RelayedCommand SelectConcreteCommand => new(SelectConcrete, CanSelectConcrete);

    public RelayedCommand SelectNextCircularCommand => new(SelectNextCircular);

    public RelayedCommand SelectPreviousCircularCommand => new(SelectPreviousCircular);

    private void SelectNext(object? parameter = null)
    {
        CurrentItem += 1;
        SelectedViewModel = ModelList[CurrentItem];
    }

    private bool CanSelectNext(object? parameter = null)
        => CurrentItem < ModelList.Count - 1;

    private void SelectPrevious(object? parameter = null)
    {
        CurrentItem -= 1;
        SelectedViewModel = ModelList[CurrentItem];
    }

    private bool CanSelectPrevious(object? parameter = null)
        => CurrentItem - 1 >= 0;

    private void SelectConcrete(object? paramater = null)
    {
        var currentType = (paramater as Type)!;

        Debug.WriteLine(paramater);

        SelectedViewModel = ModelList.FirstOrDefault(vievModel => vievModel.GetType().Equals(currentType));
    }

    private bool CanSelectConcrete(object? parameter = null)
        => parameter is Type type && ModelList.Any(viewModel => viewModel.GetType().Equals(type));

    private void SelectNextCircular(object? parmeter = null)
    {
        CurrentItem = (CurrentItem + 1) % ModelList.Count;
        SelectedViewModel = ModelList[CurrentItem];
    }

    private void SelectPreviousCircular(object? parmeter = null)
    {
        CurrentItem = (CurrentItem - 1 + ModelList.Count) % ModelList.Count;
        SelectedViewModel = ModelList[CurrentItem];
    }
}

