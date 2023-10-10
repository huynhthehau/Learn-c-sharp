using Woker.Contracts.Repositories;

namespace Woker.Persistence.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly WokerDbContext _context;

        public LogRepository(WokerDbContext context)
        {
            _context = context;
        }

        public async Task RemoveLogsAfterPeriodOfTime(DateTime date)
        {
            var logs = _context.Logs.Where(x => x.Created < date);
            _context.Logs.RemoveRange(logs);
            await _context.SaveChangesAsync();
        }
    }
}
