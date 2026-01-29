using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;
namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Coordinators.XML")]
[XmlType(TypeName = "Coordinator")]
public class CoordinatorEntity : IIndexable
{
    public int Id { get; set; }
    [DisplayName("ФИО")]
    [Required(ErrorMessage = "Укажите ФИО!")]
    public string Name { get; set; } = null!;
    [DisplayName("Ссылка")]
    [Required(ErrorMessage = "Укажите ссылку!")]
    public string Url { get; set; } = null!;
    [ValidateNever]
    public string Image { get; set; } = null!;
}