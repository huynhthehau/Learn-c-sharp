namespace Woker.Contracts.Repositories
{
    public interface ILogRepository
    {
        Task RemoveLogsAfterPeriodOfTime(DateTime date);
    }
}
