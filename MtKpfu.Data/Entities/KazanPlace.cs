using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MtKpfu.Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MtKpfu.Data.Entities;

public class KazanPlace : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; }
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    public string Description { get; set; }
    [ValidateNever]
    public string Image { get; set; }
}
