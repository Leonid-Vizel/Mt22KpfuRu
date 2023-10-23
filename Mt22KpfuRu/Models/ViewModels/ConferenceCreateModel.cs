using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models.ViewModels;

public class ConferenceCreateModel
{
    [DisplayName("Год")]
    [Required(ErrorMessage = "Укажите год!")]
    public short Year { get; set; }
    [DisplayName("PDF файл программы")]
    public IFormFile? File1 { get; set; }
    [DisplayName("PDF файл тезисов")]
    public IFormFile? File2 { get; set; }
    [DisplayName("PDF файл победителей")]
    public IFormFile? File3 { get; set; }
}
