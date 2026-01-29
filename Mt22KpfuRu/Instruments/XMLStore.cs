using System.Xml.Serialization;

namespace Mt22KpfuRu.Instruments;

public class XMLStore<T> where T : IIndexable
{
    public List<T> List { get; set; }
    public string XMLPath { get; set; }
    public bool AlwaysSearch { get; set; }
    private XmlSerializer ListSerializer { get; set; }
    private readonly object _sync = new object();

    public XMLStore(string XMLPath, bool alwaysSearch = true)
    {
        ListSerializer = new XmlSerializer(typeof(List<T>));
        this.XMLPath = XMLPath;
        AlwaysSearch = alwaysSearch;
        LoadData();
    }

    public void LoadData()
    {
        lock (_sync)
        {
            if (File.Exists(XMLPath))
            {
                using (Stream reader = new FileStream(XMLPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    List = ListSerializer.Deserialize(reader) as List<T>;
                }
            }
            if (List == null)
            {
                List = new List<T>();
                RewriteListUnsafe();
            }
        }
    }

    public void RewriteList()
    {
        lock (_sync)
        {
            RewriteListUnsafe();
        }
    }

    private void RewriteListUnsafe()
    {
        // Write-through to avoid corrupting the main file on partial write.
        var dir = Path.GetDirectoryName(XMLPath);
        if (!string.IsNullOrEmpty(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var tmp = XMLPath + ".tmp";
        using (var writer = new StreamWriter(tmp, false))
        {
            ListSerializer.Serialize(writer, List);
        }
        File.Move(tmp, XMLPath, true);
    }

    private int GetNextIndex()
    {
        if (List.Count == 0)
        {
            return 1;
        }
        if (AlwaysSearch)
        {
            var ordered = List.OrderBy(x => x.Id).ToList();
            int last = ordered[0].Id;
            for (int i = 1; i < ordered.Count; i++)
            {
                if (ordered[i].Id != last + 1)
                {
                    return last + 1;
                }
                last = ordered[i].Id;
            }
            return last + 1;
        }
        return List.Max(x => x.Id) + 1;
    }

    public void Add(T item)
    {
        lock (_sync)
        {
            item.Id = GetNextIndex();
            List.Add(item);
            RewriteListUnsafe();
        }
    }

    public void Delete(T item)
    {
        lock (_sync)
        {
            List.Remove(item);
            RewriteListUnsafe();
        }
    }
}
