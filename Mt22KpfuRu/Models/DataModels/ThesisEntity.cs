using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Thesis.XML")]
[XmlType(TypeName = "Thesis")]
public class ThesisEntity : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; } = null!;
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    public string Description { get; set; } = null!;
}