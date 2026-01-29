using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Dates.XML")]
[XmlType(TypeName = "Date")]
public class DateEntity : IIndexable
{
    public int Id { get; set; }

    [DisplayName("Дата")]
    [Required(ErrorMessage = "Укажите дату!")]
    public DateTime DateTime { get; set; }

    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; } = null!;

    [DisplayName("Формат отображения")]
    [Required(ErrorMessage = "Укажите формат отображения!")]
    public bool ShowTime { get; set; }
}
