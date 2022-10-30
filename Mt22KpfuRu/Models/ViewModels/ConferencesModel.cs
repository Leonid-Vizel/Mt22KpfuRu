namespace Mt22KpfuRu.Models;
public class ConferencesModel
{
    public List<Conference> Conferences { get; set; }
    public ConferencesModel Copy()
    {
        return new ConferencesModel()
        {
            Conferences = Conferences.OrderByDescending(x => x.Year).ToList()
        };
    }
}