using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MtKpfu.Data.Interfaces;

namespace MtKpfu.Data.Entities;

public class Orgcom : IIndexable
{
    public int Id { get; set; }
    [DisplayName("ФИО")]
    [Required(ErrorMessage = "Укажите ФИО!")]
    public string Name { get; set; }
    [DisplayName("Ссылка")]
    public string? Url { get; set; }
}
