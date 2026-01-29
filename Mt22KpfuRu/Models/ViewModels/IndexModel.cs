using Mt22KpfuRu.Models.DataModels;
using X.PagedList;
namespace Mt22KpfuRu.Models.ViewModels;
public class IndexModel
{
    public IPagedList<NewsEntity> News { get; set; }
    public List<DateEntity> Dates { get; set; }
    public List<FastLinkEntity> FastLinks { get; set; }
}
