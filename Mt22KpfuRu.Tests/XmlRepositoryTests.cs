using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
using Mt22KpfuRu.Tests.TestUtils;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class XmlRepositoryTests
{
    [StoreFile("TestEntities.XML")]
    public sealed class TestEntity : IIndexable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    [Fact]
    public void Add_AssignsSequentialAndGapFillingIds()
    {
        using var dir = new TempDir("xmlrepo");
        var env = new FakeHostEnvironment(dir.Path);
        var storageRoot = new StorageRootProvider(env);
        var fileNames = new StoreFileNameProvider();

        var repo = new XmlRepository<TestEntity>(storageRoot, fileNames);

        repo.Add(new TestEntity { Name = "one" });
        repo.Add(new TestEntity { Name = "two" });
        repo.Add(new TestEntity { Name = "three" });

        Assert.Equal(3, repo.Items.Count);
        Assert.Equal(new[] { 1, 2, 3 }, repo.Items.OrderBy(x => x.Id).Select(x => x.Id).ToArray());

        // delete Id=2 and add new -> should fill gap (2)
        var toDelete = repo.FindById(2);
        Assert.NotNull(toDelete);
        repo.Delete(toDelete!);
        repo.Add(new TestEntity { Name = "new" });

        Assert.Contains(repo.Items, x => x.Id == 2);

        // ensure file exists
        var expectedPath = System.IO.Path.Combine(storageRoot.StoragePath, "TestEntities.XML");
        Assert.True(File.Exists(expectedPath));
    }
}
