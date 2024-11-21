using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MtKpfu.Data.Interfaces;

namespace MtKpfu.Data.Entities;

public class Coordinator : IIndexable
{
    public int Id { get; set; }
    [DisplayName("ФИО")]
    [Required(ErrorMessage = "Укажите ФИО!")]
    public string Name { get; set; }
    [DisplayName("Ссылка")]
    [Required(ErrorMessage = "Укажите ссылку!")]
    public string Url { get; set; }
    [ValidateNever]
    public string Image { get; set; }
}
