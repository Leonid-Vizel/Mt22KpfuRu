using MtKpfu.Data.Interfaces;

namespace MtKpfu.Data.Entities;

public class HistoryItem : IIndexable
{
    public int Id { get; set; }
    public short Year { get; set; }
    public bool Program { get; set; }
    public bool Thesis { get; set; }
    public bool Winners { get; set; }

    public HistoryItem(short year, bool program, bool thesis, bool winners)
    {
        Year = year;
        Program = program;
        Thesis = thesis;
        Winners = winners;
    }

    public HistoryItem() { }
}
