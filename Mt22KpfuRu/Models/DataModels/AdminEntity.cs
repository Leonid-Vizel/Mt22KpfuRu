using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Models.DataModels;

[StoreFile("Admins.XML")]
[XmlType(TypeName = "Admin")]
public class AdminEntity : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Никнейм")]
    [Required(ErrorMessage = "Укажите никнейм!")]
    public string Name { get; set; } = null!;
    [DisplayName("Логин(почта)")]
    [EmailAddress(ErrorMessage = "Неверной формат почты!")]
    [Required(ErrorMessage = "Укажите почту!")]
    public string Login { get; set; } = null!;
    [DisplayName("Пароль")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль!")]
    public string HashPassword { get; set; } = null!;
}