using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Models;

public class Thesis : IIndexable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Index { get; set; }
}
