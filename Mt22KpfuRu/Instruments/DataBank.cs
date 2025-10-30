using Mt22KpfuRu.Models;
using X.PagedList.Extensions;

namespace Mt22KpfuRu.Instruments;

public static class DataBank
{
    public static XMLStore<Admin> AdminStore { get; set; } = null!;
    public static XMLStore<News> NewsStore { get; set; } = null!;
    public static XMLStore<Date> DateStore { get; set; } = null!;
    public static XMLStore<FastLink> FastLinkStore { get; set; } = null!;
    public static XMLStore<ProgramPart> ProgramPartStore { get; set; } = null!;
    public static XMLStore<Conference> ConferenceStore { get; set; } = null!;
    public static XMLStore<KazanPlace> KazanStore { get; set; } = null!;
    public static XMLStore<ExcursionPart> ExcursionStore { get; set; } = null!;
    public static XMLStore<Thesis> ThesisStore { get; set; } = null!;
    public static XMLStore<Coordinator> CoordinatorStore { get; set; } = null!;
    public static XMLStore<Orgcom> OrgcomStore { get; set; } = null!;
    public static XMLStore<Progcom> ProgcomStore { get; set; } = null!;

    public static IndexModel GetIndexModel(int page = 1)
    {
        return new IndexModel()
        {
            Dates = DateStore.List,
            FastLinks = FastLinkStore.List,
            News = NewsStore.List.OrderByDescending(x => x.CreateTime).ToPagedList(page, 6)
        };
    }
    public static ProgramModel GetProgramModel()
    {
        return new ProgramModel()
        {
            Parts = ProgramPartStore.List.GroupBy(x => x.Date).ToList()
        };
    }
    public static ConferencesModel GetConferencesModel()
    {
        return new ConferencesModel()
        {
            Conferences = ConferenceStore.List.OrderByDescending(x=>x.Year).ToList()
        };
    }
    public static KazanModel GetKazanModel()
    {
        return new KazanModel()
        {
            Places = KazanStore.List
        };
    }
    public static ExcursionModel GetExcursionModel()
    {
        return new ExcursionModel()
        {
            Parts = ExcursionStore.List
        };
    }
    public static MapModel GetMapModel()
    {
        return new MapModel()
        {
            YandexFrame = "<iframe src=\"https://yandex.ru/map-widget/v1/?um=constructor%3Ab75ac822ac159b3eda9e9a7b43cac62db4f5e8ff234b06031aee6b5542f4ecfb&amp;source=constructor\" width=\"100%\" height=\"660\" frameborder=\"0\"></iframe>"
        };
    }
    public static AboutModel GetAboutModel()
    {
        return new AboutModel()
        {
            Coordinators = CoordinatorStore.List,
            Orgcoms = OrgcomStore.List,
            Progcoms = ProgcomStore.List,
            Thesises = ThesisStore.List
        };
    }

    public static void Initialize(string mainPath)
    {
        string path = Path.Combine(mainPath, "Storage");
        DateStore = new XMLStore<Date>(Path.Combine(path, "Dates.XML"));
        AdminStore = new XMLStore<Admin>(Path.Combine(path, "Admins.XML"));
        NewsStore = new XMLStore<News>(Path.Combine(path, "News.XML"));
        FastLinkStore = new XMLStore<FastLink>(Path.Combine(path, "Links.XML"));
        ProgramPartStore = new XMLStore<ProgramPart>(Path.Combine(path, "Program.XML"));
        ConferenceStore = new XMLStore<Conference>(Path.Combine(path, "History.XML"));
        KazanStore = new XMLStore<KazanPlace>(Path.Combine(path, "Kazan.XML"));
        ExcursionStore = new XMLStore<ExcursionPart>(Path.Combine(path, "Excursion.XML"));
        ThesisStore = new XMLStore<Thesis>(Path.Combine(path, "Thesis.XML"));
        ProgcomStore = new XMLStore<Progcom>(Path.Combine(path, "ProgComs.XML"));
        OrgcomStore = new XMLStore<Orgcom>(Path.Combine(path, "OrgComs.XML"));
        CoordinatorStore = new XMLStore<Coordinator>(Path.Combine(path, "Coordinators.XML"));
    }
}
