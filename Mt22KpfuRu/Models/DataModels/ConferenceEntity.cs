using System.Xml.Serialization;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("History.XML")]
[XmlType(TypeName = "Conference")]
public class ConferenceEntity : IIndexable
{
    public int Id { get; set; }
    public short Year { get; set; }
    public bool Program { get; set; }
    public bool Thesis { get; set; }
    public bool Winners { get; set; }

    public ConferenceEntity(short year, bool program, bool thesis, bool winners)
    {
        Year = year;
        Program = program;
        Thesis = thesis;
        Winners = winners;
    }

    public ConferenceEntity() { }
}