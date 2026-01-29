namespace Mt22KpfuRu.Services.Storage;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class StoreFileAttribute : Attribute
{
    public string FileName { get; }

    public StoreFileAttribute(string fileName)
    {
        FileName = fileName;
    }
}
