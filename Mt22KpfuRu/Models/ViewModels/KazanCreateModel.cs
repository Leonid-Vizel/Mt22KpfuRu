using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mt22KpfuRu.Models.ViewModels;

public class KazanCreateModel : KazanPlace
{
    [DisplayName("Изображение")]
    [Required(ErrorMessage = "Прикрепите изображение!")]
    public IFormFile File { get; set; }
}
