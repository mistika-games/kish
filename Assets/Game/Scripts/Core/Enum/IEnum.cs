using System.Collections.Generic;

namespace Core.Enum
{
    public interface IEnum<T> : IEnumerable<T>
    {
        int Count { get; }
        IEnumerable<string> Keys { get; }

        int ToIndex(T item);
        bool TryFromIndex(int index, out T item);

        string ToId(T item);
        bool TryFromId(string id, out T item);
    }
}