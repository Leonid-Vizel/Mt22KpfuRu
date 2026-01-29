using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mt22KpfuRu.Models.DataModels;

namespace Mt22KpfuRu.Models.ViewModels;

public class ExcursionCreateModel : ExcursionPartEntity
{
    [DisplayName("Изображение #1")]
    [Required(ErrorMessage = "Прикрепите хотя бы одно изображение!")]
    public IFormFile File1 { get; set; }

    [DisplayName("Изображение #2")]
    public IFormFile? File2 { get; set; }
}
