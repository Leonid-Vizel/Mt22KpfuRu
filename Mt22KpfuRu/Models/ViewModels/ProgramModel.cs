using Mt22KpfuRu.Models.DataModels;

namespace Mt22KpfuRu.Models.ViewModels;

public class ProgramModel
{
    public List<IGrouping<DateOnly, ProgramPartEntity>> Parts { get; set; }
}
