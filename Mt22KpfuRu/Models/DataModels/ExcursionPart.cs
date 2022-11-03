using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Models;

public class ExcursionPart : IIndexable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image1 { get; set; }
    public string? Image2 { get; set; }
}
