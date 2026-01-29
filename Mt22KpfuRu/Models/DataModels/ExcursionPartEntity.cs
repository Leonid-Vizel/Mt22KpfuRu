using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Excursion.XML")]
[XmlType(TypeName = "ExcursionPart")]
public class ExcursionPartEntity : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; } = null!;
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    public string Description { get; set; } = null!;
    [ValidateNever]
    public string Image1 { get; set; } = null!;
    [ValidateNever]
    public string? Image2 { get; set; }
}