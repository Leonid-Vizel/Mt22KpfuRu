using X.PagedList;
namespace Mt22KpfuRu.Models;
public class IndexModel
{
    public List<News> TotalNews { get; set; }
    public IPagedList<News> News { get; set; }
    public List<Date> Dates { get; set; }
    public List<FastLink> FastLinks { get; set; }

    public IndexModel CopyFromPage(int page)
    {
        return new IndexModel()
        {
            TotalNews = TotalNews,
            News = TotalNews.ToPagedList(page, 6),
            FastLinks = FastLinks,
            Dates = Dates
        };
    }
}
