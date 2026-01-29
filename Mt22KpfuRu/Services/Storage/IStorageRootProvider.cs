namespace Mt22KpfuRu.Services.Storage;

public interface IStorageRootProvider
{
    string StoragePath { get; }
}

public sealed class StorageRootProvider : IStorageRootProvider
{
    public string StoragePath { get; }

    public StorageRootProvider(IHostEnvironment env)
    {
        var contentRoot = env.ContentRootPath;

        StoragePath = Path.Combine(contentRoot, "App_Data", "Storage");
        Directory.CreateDirectory(StoragePath);

        var legacyPath = Path.Combine(contentRoot, "wwwroot", "Storage");
        if (Directory.Exists(legacyPath))
        {
            foreach (var file in Directory.GetFiles(legacyPath, "*.XML"))
            {
                var dest = Path.Combine(StoragePath, Path.GetFileName(file));
                if (!File.Exists(dest))
                {
                    File.Copy(file, dest);
                }
            }
        }
    }
}