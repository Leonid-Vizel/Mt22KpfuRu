namespace Mt22KpfuRu.Models;

public class Conference
{
    public short Year { get; set; }
    public bool Program { get; set; }
    public bool Thesis { get; set; }
    public bool Winners { get; set; }

    public Conference(short year, bool program, bool thesis, bool winners)
    {
        Year = year;
        Program = program;
        Thesis = thesis;
        Winners = winners;
    }

    public Conference() { }
}
