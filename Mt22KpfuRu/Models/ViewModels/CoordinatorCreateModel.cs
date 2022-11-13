using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mt22KpfuRu.Models.ViewModels
{
    public class CoordinatorCreateModel : Coordinator
    {
        [DisplayName("Изображение")]
        [Required(ErrorMessage = "Прикрепите изображение!")]
        public IFormFile File { get; set; }
    }
}
