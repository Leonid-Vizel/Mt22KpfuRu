using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Models.ViewModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Services.Admin;

public sealed class AdminPanelService : IAdminPanelService
{
    private readonly IRepository<AdminEntity> _admins;
    private readonly IRepository<DateEntity> _dates;
    private readonly IRepository<FastLinkEntity> _links;
    private readonly IRepository<NewsEntity> _news;
    private readonly IRepository<ProgramPartEntity> _program;
    private readonly IRepository<ConferenceEntity> _conferences;
    private readonly IRepository<ExcursionPartEntity> _excursions;
    private readonly IRepository<KazanPlaceEntity> _kazan;
    private readonly IRepository<ThesisEntity> _thesis;
    private readonly IRepository<OrgcomEntity> _orgcoms;
    private readonly IRepository<ProgcomEntity> _progcoms;
    private readonly IRepository<CoordinatorEntity> _coordinators;

    public AdminPanelService(
        IRepository<AdminEntity> admins,
        IRepository<DateEntity> dates,
        IRepository<FastLinkEntity> links,
        IRepository<NewsEntity> news,
        IRepository<ProgramPartEntity> program,
        IRepository<ConferenceEntity> conferences,
        IRepository<ExcursionPartEntity> excursions,
        IRepository<KazanPlaceEntity> kazan,
        IRepository<ThesisEntity> thesis,
        IRepository<OrgcomEntity> orgcoms,
        IRepository<ProgcomEntity> progcoms,
        IRepository<CoordinatorEntity> coordinators)
    {
        _admins = admins;
        _dates = dates;
        _links = links;
        _news = news;
        _program = program;
        _conferences = conferences;
        _excursions = excursions;
        _kazan = kazan;
        _thesis = thesis;
        _orgcoms = orgcoms;
        _progcoms = progcoms;
        _coordinators = coordinators;
    }

    public AdminPanelModel Build()
        => new AdminPanelModel
        {
            Admins = _admins.Items.ToList(),
            Dates = _dates.Items.ToList(),
            FastLinks = _links.Items.ToList(),
            News = _news.Items.ToList(),
            ProgramParts = _program.Items.ToList(),
            Conferences = _conferences.Items.ToList(),
            Excursions = _excursions.Items.ToList(),
            KazanPlaces = _kazan.Items.ToList(),
            Thesis = _thesis.Items.ToList(),
            Orgcoms = _orgcoms.Items.ToList(),
            Progcoms = _progcoms.Items.ToList(),
            Coordinators = _coordinators.Items.ToList(),
        };
}
