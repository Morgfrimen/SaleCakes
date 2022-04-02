using System.Collections.ObjectModel;

namespace Shared.Extension;

public static class Extension
{
    public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> range)
    {
        foreach (T? item in range)
        {
            collection.Add(item);
        }

        return collection;
    }
}