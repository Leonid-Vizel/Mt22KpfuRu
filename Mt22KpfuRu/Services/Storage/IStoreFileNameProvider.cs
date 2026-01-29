using System.Collections.Concurrent;

namespace Mt22KpfuRu.Services.Storage;

public interface IStoreFileNameProvider
{
    string GetFileName<T>();
}

public sealed class StoreFileNameProvider : IStoreFileNameProvider
{
    private readonly ConcurrentDictionary<Type, string> _cache = new();

    public string GetFileName<T>()
    {
        return _cache.GetOrAdd(typeof(T), static t =>
        {
            var attr = t.GetCustomAttributes(typeof(StoreFileAttribute), inherit: false)
                        .OfType<StoreFileAttribute>()
                        .FirstOrDefault();

            if (attr == null || string.IsNullOrWhiteSpace(attr.FileName))
            {
                throw new InvalidOperationException(
                    $"Model type '{t.FullName}' must be annotated with [StoreFile(\"...\")].");
            }
            return attr.FileName;
        });
    }
}