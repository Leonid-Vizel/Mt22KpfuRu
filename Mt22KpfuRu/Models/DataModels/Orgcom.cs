using Mt22KpfuRu.Instruments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mt22KpfuRu.Models;

public class Orgcom : IIndexable
{
    public int Id { get; set; }
    [DisplayName("ФИО")]
    [Required(ErrorMessage = "Укажите ФИО!")]
    public string Name { get; set; }
    [DisplayName("Ссылка")]
    public string? Url { get; set; }
}
