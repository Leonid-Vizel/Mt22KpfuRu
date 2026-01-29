using Mt22KpfuRu.Instruments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Program.XML")]
[XmlType(TypeName = "ProgramPart")]
public class ProgramPartEntity : IIndexable
{
    public int Id { get; set; }
    [XmlIgnore]
    [DisplayName("Дата мероприятия")]
    [Required(ErrorMessage = "Укажите дату мероприятия!")]
    public DateOnly Date { get; set; }
    [XmlIgnore]
    [DisplayName("Время начала")]
    [Required(ErrorMessage = "Укажите время начала мероприятия!")]
    public TimeOnly TimeStart { get; set; }
    [XmlIgnore]
    [DisplayName("Время окончания")]
    [Required(ErrorMessage = "Укажите время окончания мероприятия!")]
    public TimeOnly TimeEnd { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название мероприятия!")]
    public string Name { get; set; } = null!;
    [DisplayName("Место проведения")]
    [Required(ErrorMessage = "Укажите место проведения мероприятия!")]
    public string Place { get; set; } = null!;

    public string DateXml
    {
        get => Date.ToString("dd.MM.yyyy");
        set => Date = DateOnly.ParseExact(value, "dd.MM.yyyy");
    }

    public string StartTimeXml
    {
        get => TimeStart.ToString("HH:mm");
        set => TimeStart = TimeOnly.ParseExact(value, "HH:mm");
    }

    public string EndTimeXml
    {
        get => TimeEnd.ToString("HH:mm");
        set => TimeEnd = TimeOnly.ParseExact(value, "HH:mm");
    }

    [XmlIgnore]
    public DateTime DateFromInput
    {
        set
        {
            Date = new DateOnly(value.Year, value.Month, value.Day);
        }
        get
        {
            return new DateTime(Date.Year, Date.Month, Date.Day);
        }
    }

    [XmlIgnore]
    public DateTime TimeStartFromInput
    {
        set
        {
            TimeStart = new TimeOnly(value.Hour, value.Minute, value.Second);
        }
        get
        {
            return new DateTime(1, 1, 1, TimeStart.Hour, TimeStart.Minute, TimeStart.Second);
        }
    }

    [XmlIgnore]
    public DateTime TimeEndFromInput
    {
        set
        {
            TimeEnd = new TimeOnly(value.Hour, value.Minute, value.Second);
        }
        get
        {
            return new DateTime(1, 1, 1, TimeEnd.Hour, TimeEnd.Minute, TimeEnd.Second);
        }
    }
}