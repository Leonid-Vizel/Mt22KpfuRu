using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Services.Storage;

/// <summary>
/// Simple repository abstraction over XML-backed storage.
/// </summary>
public interface IRepository<T> where T : class, IIndexable
{
    IReadOnlyList<T> Items { get; }
    T? FindById(int id);
    void Add(T item);
    void Delete(T item);
    void SaveChanges();
}

public sealed class XmlRepository<T> : IRepository<T> where T : class, IIndexable
{
    private readonly XMLStore<T> _store;

    public XmlRepository(IStorageRootProvider storageRoot, IStoreFileNameProvider fileNames)
    {
        string file = fileNames.GetFileName<T>();
        string path = Path.Combine(storageRoot.StoragePath, file);
        _store = new XMLStore<T>(path);
    }

    public IReadOnlyList<T> Items => _store.List;

    public T? FindById(int id) => _store.List.FirstOrDefault(x => x.Id == id);

    public void Add(T item) => _store.Add(item);

    public void Delete(T item) => _store.Delete(item);

    public void SaveChanges() => _store.RewriteList();
}
