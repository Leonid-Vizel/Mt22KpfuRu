using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Models;

public class Coordinator : IIndexable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Image { get; set; }
}
