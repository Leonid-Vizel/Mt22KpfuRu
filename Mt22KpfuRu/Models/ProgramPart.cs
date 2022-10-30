using System.ComponentModel.DataAnnotations;

namespace Mt22KpfuRu.Models
{
    public class ProgramPart
    {
        public DateOnly Date { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
    }
}
