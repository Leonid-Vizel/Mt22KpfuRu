using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models
{
    public class ProgramPart
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите дату проведения")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Укажите дату начала")]
        public short TimeStart  { get; set; }
        [Required(ErrorMessage = "Укажите дату конца")]
        public short TimeEnd { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
    }
}
