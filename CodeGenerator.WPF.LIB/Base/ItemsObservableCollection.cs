using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CodeGenerator.WPF.LIB.Base;

public class ItemsObservableCollection<T>: ObservableCollection<T>
    where T : INotifyPropertyChanged
{
    private readonly List<PropertyChangedEventHandler> _handlers = new();

    public ItemsObservableCollection(): base() { }

    public ItemsObservableCollection(IList<T> list): base(list)
    {
        CopyFrom(list);
    }

    public ItemsObservableCollection(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        CopyFrom(collection);
    }

    public event PropertyChangedEventHandler? ItemPropertyChanged
    {
        add
        {
            if (value is null) return;
            
            _handlers.Add(value);
            
            foreach (var item in Items)
                item.PropertyChanged += value;
        }
        remove
        {
            if (value is null) return;
            
            _handlers.Remove(value);
            
            foreach (var item in Items)
                item.PropertyChanged -= value;
        }
    }

    protected override void InsertItem(int index, T item)
    {
        _handlers.ForEach(handler => item.PropertyChanged += handler);
        base.InsertItem(index, item);
    }

    protected override void RemoveItem(int index)
    {
        var item = Items[index];
        _handlers.ForEach(handler => item.PropertyChanged -= handler);
        base.RemoveItem(index);
    }

    private void CopyFrom(IEnumerable<T> collection)
    {
        IList<T> items = Items;

        if (collection is null || items is null)
            return;

        using IEnumerator<T> enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext())
            items.Add(enumerator.Current);
    }
}
