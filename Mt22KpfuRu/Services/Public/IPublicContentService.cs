using Mt22KpfuRu.Models.ViewModels;

namespace Mt22KpfuRu.Services.Public;

public interface IPublicContentService
{
    IndexModel GetIndexModel(int page = 1);
    ConferencesModel GetConferencesModel();
    ProgramModel GetProgramModel();
    ExcursionModel GetExcursionModel();
    KazanModel GetKazanModel();
    MapModel GetMapModel();
    AboutModel GetAboutModel();
}
