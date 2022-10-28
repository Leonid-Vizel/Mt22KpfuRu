using Microsoft.EntityFrameworkCore;

namespace Mt22KpfuRu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
