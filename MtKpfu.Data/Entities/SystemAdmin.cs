using MtKpfu.Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MtKpfu.Data.Entities;

public sealed class SystemAdmin : IIndexable
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
