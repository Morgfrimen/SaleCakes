using System.Collections.ObjectModel;

namespace Shared.Extension;

public static class Extension
{
    public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> range)
    {
        foreach (var item in range) collection.Add(item);

        return collection;
    }
}