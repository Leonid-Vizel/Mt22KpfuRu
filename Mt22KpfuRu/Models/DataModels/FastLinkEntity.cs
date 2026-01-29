using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Links.XML")]
[XmlType(TypeName = "FastLink")]
public class FastLinkEntity : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Надпись")]
    [Required(ErrorMessage ="Укажите надпись ссылки!")]
    public string Name { get; set; } = null!;
    [DisplayName("Ссылка")]
    [Required(ErrorMessage = "Укажите ссылку!")]
    public string Url { get; set; } = null!;
}