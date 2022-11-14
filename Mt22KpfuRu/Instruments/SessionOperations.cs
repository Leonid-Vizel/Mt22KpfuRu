using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;

namespace Mt22KpfuRu.Instruments
{
    public static class SessionOperations
    {
        public static async Task EndSessionsByLogin(ISession userSession, string userLogin)
        {
            var trueFunction = () => true;
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            MemoryDistributedCache cache = userSession.GetType().GetField("_cache", flags).GetValue(userSession) as MemoryDistributedCache;
            MemoryCache _memCache = cache.GetType().GetField("_memCache", flags).GetValue(cache) as MemoryCache;
            var collection = _memCache.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_memCache);
            IDictionary keyCollection = collection as IDictionary;
            List<(string, string)> loginsActive = new List<(string, string)>();
            foreach (var key in keyCollection.Keys)
            {
                DistributedSessionStore store = new DistributedSessionStore(cache, new LoggerFactory());
                ISession session = store.Create(key.ToString(), TimeSpan.FromHours(6), TimeSpan.FromSeconds(5), trueFunction, false);
                string? login = session.GetString("Login");
                if (login != null && login.Equals(userLogin))
                {
                    session.Remove("Login");
                    await session.CommitAsync();
                }
            }
        }
    }
}
