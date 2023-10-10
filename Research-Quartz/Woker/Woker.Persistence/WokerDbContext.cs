using Microsoft.EntityFrameworkCore;
using Woker.Contracts.Entities;

namespace Woker.Persistence
{
    public class WokerDbContext : DbContext
    {
        public WokerDbContext(DbContextOptions<WokerDbContext> dbContextOptions) : base(dbContextOptions)
        {
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Log> Logs { get; set; }
    }
}