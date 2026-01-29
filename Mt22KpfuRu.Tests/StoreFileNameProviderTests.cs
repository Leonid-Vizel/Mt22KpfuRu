using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class StoreFileNameProviderTests
{
    [StoreFile("Test.XML")]
    private sealed class TestModel : IIndexable
    {
        public int Id { get; set; }
    }

    private sealed class NoAttributeModel : IIndexable
    {
        public int Id { get; set; }
    }

    [Fact]
    public void GetFileName_ReturnsAttributeValue_AndCaches()
    {
        var provider = new StoreFileNameProvider();

        var f1 = provider.GetFileName<TestModel>();
        var f2 = provider.GetFileName<TestModel>();

        Assert.Equal("Test.XML", f1);
        Assert.Equal(f1, f2);
    }

    [Fact]
    public void GetFileName_ThrowsWhenMissingAttribute()
    {
        var provider = new StoreFileNameProvider();
        var ex = Assert.Throws<InvalidOperationException>(() => provider.GetFileName<NoAttributeModel>());
        Assert.Contains("StoreFile", ex.Message, StringComparison.OrdinalIgnoreCase);
    }
}
