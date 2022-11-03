using System.Xml.Serialization;

namespace Mt22KpfuRu.Models
{
    public class ProgramPart
    {
        [XmlIgnore]
        public DateOnly Date { get; set; }
        [XmlIgnore]
        public TimeOnly TimeStart { get; set; }
        [XmlIgnore]
        public TimeOnly TimeEnd { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }

        public string DateXml
        {
            get => Date.ToString("dd.MM.yyyy");
            set => Date = DateOnly.ParseExact(value, "dd.MM.yyyy");
        }

        public string StartTimeXml
        {
            get => TimeStart.ToString("HH:mm");
            set => TimeStart = TimeOnly.ParseExact(value, "HH:mm");
        }

        public string EndTimeXml
        {
            get => TimeEnd.ToString("HH:mm");
            set => TimeEnd = TimeOnly.ParseExact(value, "HH:mm");
        }
    }
}
