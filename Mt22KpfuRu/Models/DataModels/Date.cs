using Mt22KpfuRu.Instruments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models
{
    public class Date : IIndexable
    {
        public int Id { get; set; }
        [DisplayName("Дата")]
        [Required(ErrorMessage = "Укажите дату!")]
        public DateTime DateTime { get; set; }
        [DisplayName("Название")]
        [Required(ErrorMessage = "Укажите название!")]
        public string Name { get; set; }
        [DisplayName("Формат отображения")]
        [Required(ErrorMessage = "Укажите формат отображения!")]
        public bool ShowTime { get; set; }
    }
}
