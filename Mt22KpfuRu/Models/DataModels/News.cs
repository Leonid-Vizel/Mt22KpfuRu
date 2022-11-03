using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Models
{
    public class News : IIndexable
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateTime { get; set; }
    }
}
