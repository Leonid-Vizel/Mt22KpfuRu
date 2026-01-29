using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Models.ViewModels;
using Mt22KpfuRu.Services.Storage;
using X.PagedList.Extensions;

namespace Mt22KpfuRu.Services.Public;

public sealed class PublicContentService : IPublicContentService
{
    private readonly IRepository<DateEntity> _dates;
    private readonly IRepository<FastLinkEntity> _links;
    private readonly IRepository<NewsEntity> _news;
    private readonly IRepository<ProgramPartEntity> _program;
    private readonly IRepository<ConferenceEntity> _conferences;
    private readonly IRepository<KazanPlaceEntity> _kazan;
    private readonly IRepository<ExcursionPartEntity> _excursions;
    private readonly IRepository<ThesisEntity> _thesis;
    private readonly IRepository<CoordinatorEntity> _coordinators;
    private readonly IRepository<OrgcomEntity> _orgcoms;
    private readonly IRepository<ProgcomEntity> _progcoms;

    public PublicContentService(
        IRepository<DateEntity> dates,
        IRepository<FastLinkEntity> links,
        IRepository<NewsEntity> news,
        IRepository<ProgramPartEntity> program,
        IRepository<ConferenceEntity> conferences,
        IRepository<KazanPlaceEntity> kazan,
        IRepository<ExcursionPartEntity> excursions,
        IRepository<ThesisEntity> thesis,
        IRepository<CoordinatorEntity> coordinators,
        IRepository<OrgcomEntity> orgcoms,
        IRepository<ProgcomEntity> progcoms)
    {
        _dates = dates;
        _links = links;
        _news = news;
        _program = program;
        _conferences = conferences;
        _kazan = kazan;
        _excursions = excursions;
        _thesis = thesis;
        _coordinators = coordinators;
        _orgcoms = orgcoms;
        _progcoms = progcoms;
    }

    public IndexModel GetIndexModel(int page = 1)
        => new IndexModel
        {
            Dates = _dates.Items.ToList(),
            FastLinks = _links.Items.ToList(),
            News = _news.Items.OrderByDescending(x => x.CreateTime).ToPagedList(page, 6)
        };

    public ProgramModel GetProgramModel()
        => new ProgramModel
        {
            Parts = _program.Items.GroupBy(x => x.Date).ToList()
        };

    public ConferencesModel GetConferencesModel()
        => new ConferencesModel
        {
            Conferences = _conferences.Items.OrderByDescending(x => x.Year).ToList()
        };

    public KazanModel GetKazanModel()
        => new KazanModel
        {
            Places = _kazan.Items.ToList()
        };

    public ExcursionModel GetExcursionModel()
        => new ExcursionModel
        {
            Parts = _excursions.Items.ToList()
        };

    public MapModel GetMapModel()
        => new MapModel
        {
            YandexFrame = "<iframe src=\"https://yandex.ru/map-widget/v1/?um=constructor%3Ab75ac822ac159b3eda9e9a7b43cac62db4f5e8ff234b06031aee6b5542f4ecfb&amp;source=constructor\" width=\"100%\" height=\"660\" frameborder=\"0\"></iframe>"
        };

    public AboutModel GetAboutModel()
        => new AboutModel
        {
            Coordinators = _coordinators.Items.ToList(),
            Orgcoms = _orgcoms.Items.ToList(),
            Progcoms = _progcoms.Items.ToList(),
            Thesises = _thesis.Items.ToList()
        };
}
