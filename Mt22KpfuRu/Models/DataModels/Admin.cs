using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Models;

public class Admin : IIndexable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string HashPassword { get; set; }
}
