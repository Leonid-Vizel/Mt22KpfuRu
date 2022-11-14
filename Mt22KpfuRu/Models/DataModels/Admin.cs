using Mt22KpfuRu.Instruments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models;

public class Admin : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Никнейм")]
    [Required(ErrorMessage = "Укажите никнейм!")]
    public string Name { get; set; }
    [DisplayName("Логин(почта)")]
    [EmailAddress(ErrorMessage = "Неверной формат почты!")]
    [Required(ErrorMessage = "Укажите почту!")]
    public string Login { get; set; }
    [DisplayName("Пароль")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль!")]
    public string HashPassword { get; set; }
}
