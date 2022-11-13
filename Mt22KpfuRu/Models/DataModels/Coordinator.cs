using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Mt22KpfuRu.Instruments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mt22KpfuRu.Models;

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
