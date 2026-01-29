using Mt22KpfuRu.Models.DataModels;

namespace Mt22KpfuRu.Models.ViewModels;

public sealed class AdminPanelModel
{
    public List<AdminEntity> Admins { get; set; } = new();
    public List<DateEntity> Dates { get; set; } = new();
    public List<FastLinkEntity> FastLinks { get; set; } = new();
    public List<NewsEntity> News { get; set; } = new();
    public List<ProgramPartEntity> ProgramParts { get; set; } = new();
    public List<ConferenceEntity> Conferences { get; set; } = new();
    public List<ExcursionPartEntity> Excursions { get; set; } = new();
    public List<KazanPlaceEntity> KazanPlaces { get; set; } = new();
    public List<ThesisEntity> Thesis { get; set; } = new();
    public List<OrgcomEntity> Orgcoms { get; set; } = new();
    public List<ProgcomEntity> Progcoms { get; set; } = new();
    public List<CoordinatorEntity> Coordinators { get; set; } = new();
}
