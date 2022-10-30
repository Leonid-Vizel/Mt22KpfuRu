namespace Mt22KpfuRu.Models
{
    public class ProgramModel
    {
        public List<ProgramPart> TotalParts { get; set; }
        public List<IGrouping<DateOnly, ProgramPart>> Parts { get; set; }

        public ProgramModel Copy()
        {
            return new ProgramModel()
            {
                TotalParts = TotalParts,
                Parts = TotalParts.GroupBy(x=>x.Date).ToList()
            };
        }
    }
}
