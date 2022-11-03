using Mt22KpfuRu.Models;
using X.PagedList;

namespace Mt22KpfuRu.Instruments;

public static class DataBank
{
    public static XMLStore<Admin> AdminStore { get; set; }
    public static XMLStore<News> NewsStore { get; set; }
    public static XMLStore<Date> DateStore { get; set; }
    public static XMLStore<FastLink> FastLinkStore { get; set; }
    public static XMLStore<ProgramPart> ProgramPartStore { get; set; }
    public static XMLStore<Conference> ConferenceStore { get; set; }
    public static XMLStore<KazanPlace> KazanStore { get; set; }
    public static XMLStore<ExcursionPart> ExcursionStore { get; set; }
    public static XMLStore<Thesis> ThesisStore { get; set; }
    public static XMLStore<Coordinator> CoordinatorStore { get; set; }
    public static XMLStore<Orgcom> OrgcomStore { get; set; }

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
            Conferences = ConferenceStore.List
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
            Thesises = ThesisStore.List
        };
    }

    public static void Initialize(string mainPath)
    {
        AdminStore = new XMLStore<Admin>($"{mainPath}\\Storage\\Admins.XML");
        NewsStore = new XMLStore<News>($"{mainPath}\\Storage\\News.XML");
        DateStore = new XMLStore<Date>($"{mainPath}\\Storage\\Dates.XML");
        FastLinkStore = new XMLStore<FastLink>($"{mainPath}\\Storage\\Links.XML");
        ProgramPartStore = new XMLStore<ProgramPart>($"{mainPath}\\Storage\\Program.XML");
        ConferenceStore = new XMLStore<Conference>($"{mainPath}\\Storage\\History.XML");
        KazanStore = new XMLStore<KazanPlace>($"{mainPath}\\Storage\\Kazan.XML");
        ExcursionStore = new XMLStore<ExcursionPart>($"{mainPath}\\Storage\\Excursion.XML");
        ThesisStore = new XMLStore<Thesis>($"{mainPath}\\Storage\\Thesis.XML");
        OrgcomStore = new XMLStore<Orgcom>($"{mainPath}\\Storage\\OrgComs.XML");
        CoordinatorStore = new XMLStore<Coordinator>($"{mainPath}\\Storage\\Coordinators.XML");
    }
}
