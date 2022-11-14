using Mt22KpfuRu.Instruments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models;

public class Thesis : IIndexable
{
    public int Id { get; set; }
    [DisplayName("Название")]
    [Required(ErrorMessage = "Укажите название!")]
    public string Name { get; set; }
    [DisplayName("Описание")]
    [Required(ErrorMessage = "Укажите описание!")]
    public string Description { get; set; }
}
