using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Kazan.XML")]
[XmlType(TypeName = "KazanPlace")]
public class KazanPlaceEntity : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; } = null!;
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    public string Description { get; set; } = null!;
    [ValidateNever]
    public string Image { get; set; } = null!;
}