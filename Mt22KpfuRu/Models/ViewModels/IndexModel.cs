using X.PagedList;
namespace Mt22KpfuRu.Models;
public class IndexModel
{
    public IPagedList<News> News { get; set; }
    public List<Date> Dates { get; set; }
    public List<FastLink> FastLinks { get; set; }
}
