using Mt22KpfuRu.Instruments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models
{
    public class FastLink : IIndexable
    {
        public int Id { get; set; }
        [DisplayName("Надпись")]
        [Required(ErrorMessage ="Укажите надпись ссылки!")]
        public string Name { get; set; }
        [DisplayName("Ссылка")]
        [Required(ErrorMessage = "Укажите ссылку!")]
        public string Url { get; set; }
    }
}
