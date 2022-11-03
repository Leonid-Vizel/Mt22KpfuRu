using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Models
{
    public class Date : IIndexable
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public bool ShowTime { get; set; }
    }
}
