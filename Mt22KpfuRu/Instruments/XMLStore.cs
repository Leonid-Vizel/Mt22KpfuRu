using System.Xml.Serialization;

namespace Mt22KpfuRu.Instruments
{
    public class XMLStore<T>
    {
        public List<T> List { get; set; }
        public string XMLPath { get; set; }
        private XmlSerializer ListSerializer { get; set; }

        public XMLStore(string XMLPath)
        {
            ListSerializer = new XmlSerializer(typeof(List<T>));
            this.XMLPath = XMLPath;
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists(XMLPath))
            {
                using (Stream reader = new FileStream(XMLPath, FileMode.Open))
                {
                    List = ListSerializer.Deserialize(reader) as List<T>;
                }
            }
            if (List == null)
            {
                List = new List<T>();
                RewriteList();
            }
        }

        public void RewriteList()
        {
            using (StreamWriter writer = new StreamWriter(XMLPath))
            {
                ListSerializer.Serialize(writer, List);
            }
        }

        public void Add(T item)
        {
            List.Add(item);
            RewriteList();
        }

        public void Delete(T item)
        {
            List.Remove(item);
            RewriteList();
        }
    }
}
