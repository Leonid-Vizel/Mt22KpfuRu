using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MtKpfu.Data.Interfaces;

namespace MtKpfu.Data.Entities;

public class ExcursionPart : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; }
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    public string Description { get; set; }
    [ValidateNever]
    public string Image1 { get; set; }
    [ValidateNever]
    public string? Image2 { get; set; }
}
