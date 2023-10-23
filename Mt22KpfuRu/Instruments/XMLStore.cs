using System.Xml.Serialization;

namespace Mt22KpfuRu.Instruments;

public class XMLStore<T> where T : IIndexable
{
    public List<T> List { get; set; }
    public string XMLPath { get; set; }
    public bool AlwaysSearch { get; set; }
    private XmlSerializer ListSerializer { get; set; }

    public XMLStore(string XMLPath, bool alwaysSearch = true)
    {
        ListSerializer = new XmlSerializer(typeof(List<T>));
        this.XMLPath = XMLPath;
        AlwaysSearch = alwaysSearch;
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

    private int GetNextIndex()
    {
        if (List.Count == 0)
        {
            return 1;
        }
        if (AlwaysSearch)
        {
            int last = List.First().Id;
            List<T> entities = List.OrderBy(x => x.Id).Skip(1).ToList();
            foreach(T entity in entities)
            {
                if (entity.Id != last + 1)
                {
                    return entity.Id;
                }
                last = entity.Id;
            }
            return last + 1;
        }
        return List.Max(x => x.Id) + 1;
    }

    public void Add(T item)
    {
        item.Id = GetNextIndex();
        List.Add(item);
        RewriteList();
    }

    public void Delete(T item)
    {
        List.Remove(item);
        RewriteList();
    }
}
