using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Models.ViewModels;
using X.PagedList.Extensions;

namespace Mt22KpfuRu.Instruments;

public static class DataBank
{
    public static XMLStore<AdminEntity> AdminStore { get; set; } = null!;
    public static XMLStore<NewsEntity> NewsStore { get; set; } = null!;
    public static XMLStore<DateEntity> DateStore { get; set; } = null!;
    public static XMLStore<FastLinkEntity> FastLinkStore { get; set; } = null!;
    public static XMLStore<ProgramPartEntity> ProgramPartStore { get; set; } = null!;
    public static XMLStore<ConferenceEntity> ConferenceStore { get; set; } = null!;
    public static XMLStore<KazanPlaceEntity> KazanStore { get; set; } = null!;
    public static XMLStore<ExcursionPartEntity> ExcursionStore { get; set; } = null!;
    public static XMLStore<ThesisEntity> ThesisStore { get; set; } = null!;
    public static XMLStore<CoordinatorEntity> CoordinatorStore { get; set; } = null!;
    public static XMLStore<OrgcomEntity> OrgcomStore { get; set; } = null!;
    public static XMLStore<ProgcomEntity> ProgcomStore { get; set; } = null!;

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
            Conferences = ConferenceStore.List.OrderByDescending(x => x.Year).ToList()
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

    /// <summary>
    /// Initializes XML stores.
    /// Storage lives outside webroot at: {ContentRoot}/App_Data/Storage.
    /// If legacy storage exists at {ContentRoot}/wwwroot/Storage, missing files are copied over.
    /// </summary>
    public static void Initialize(string contentRootPath)
    {
        string newPath = Path.Combine(contentRootPath, "App_Data", "Storage");
        Directory.CreateDirectory(newPath);

        // Migrate from legacy location if present.
        string legacyPath = Path.Combine(contentRootPath, "wwwroot", "Storage");
        if (Directory.Exists(legacyPath))
        {
            foreach (string file in Directory.GetFiles(legacyPath, "*.XML"))
            {
                string dest = Path.Combine(newPath, Path.GetFileName(file));
                if (!File.Exists(dest))
                {
                    File.Copy(file, dest);
                }
            }
        }

        DateStore = new XMLStore<DateEntity>(Path.Combine(newPath, "Dates.XML"));
        AdminStore = new XMLStore<AdminEntity>(Path.Combine(newPath, "Admins.XML"));
        NewsStore = new XMLStore<NewsEntity>(Path.Combine(newPath, "News.XML"));
        FastLinkStore = new XMLStore<FastLinkEntity>(Path.Combine(newPath, "Links.XML"));
        ProgramPartStore = new XMLStore<ProgramPartEntity>(Path.Combine(newPath, "Program.XML"));
        ConferenceStore = new XMLStore<ConferenceEntity>(Path.Combine(newPath, "History.XML"));
        KazanStore = new XMLStore<KazanPlaceEntity>(Path.Combine(newPath, "Kazan.XML"));
        ExcursionStore = new XMLStore<ExcursionPartEntity>(Path.Combine(newPath, "Excursion.XML"));
        ThesisStore = new XMLStore<ThesisEntity>(Path.Combine(newPath, "Thesis.XML"));
        ProgcomStore = new XMLStore<ProgcomEntity>(Path.Combine(newPath, "ProgComs.XML"));
        OrgcomStore = new XMLStore<OrgcomEntity>(Path.Combine(newPath, "OrgComs.XML"));
        CoordinatorStore = new XMLStore<CoordinatorEntity>(Path.Combine(newPath, "Coordinators.XML"));
    }
}
