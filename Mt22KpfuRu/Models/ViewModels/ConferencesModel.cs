using Mt22KpfuRu.Models.DataModels;

namespace Mt22KpfuRu.Models.ViewModels;
public class ConferencesModel
{
    public List<ConferenceEntity> Conferences { get; set; }
    public ConferencesModel Copy()
    {
        return new ConferencesModel()
        {
            Conferences = Conferences.OrderByDescending(x => x.Year).ToList()
        };
    }
}