using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mt22KpfuRu.Models.DataModels;

namespace Mt22KpfuRu.Models.ViewModels;

public class KazanCreateModel : KazanPlaceEntity
{
    [DisplayName("Изображение")]
    [Required(ErrorMessage = "Прикрепите изображение!")]
    public IFormFile File { get; set; }
}
