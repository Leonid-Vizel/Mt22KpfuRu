using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mt22KpfuRu.Models.ViewModels
{
    public class ExcursionCreateModel : ExcursionPart
    {
        [DisplayName("Изображение #1")]
        [Required(ErrorMessage = "Прикрепите хотя бы одно изображение!")]
        public IFormFile File1 { get; set; }

        [DisplayName("Изображение #2")]
        public IFormFile? File2 { get; set; }
    }
}
