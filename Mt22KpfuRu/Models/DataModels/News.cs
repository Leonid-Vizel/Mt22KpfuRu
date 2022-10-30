namespace Mt22KpfuRu.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateTime { get; set; }
    }
}
