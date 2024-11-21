using MtKpfu.Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MtKpfu.Data.Entities;

public sealed class Thesis : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    [MinLength(1, ErrorMessage = "Укажите название!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина названия - {1} символов!")]
    public string Name { get; set; } = null!;
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    [MinLength(1, ErrorMessage = "Укажите название!")]
    [MaxLength(1000, ErrorMessage = "Максимальная длина названия - {1} символов!")]
    public string Description { get; set; } = null!;
}
