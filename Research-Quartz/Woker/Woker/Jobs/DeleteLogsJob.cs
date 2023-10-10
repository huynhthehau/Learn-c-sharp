using Microsoft.Extensions.Options;
using Quartz;
using Woker.Contracts.Repositories;
using Woker.Options;

namespace Woker.Jobs
{
    public class DeleteLogsJob : IJob
    {
        private readonly ILogRepository _logRepository;
        private readonly int _amountOfDays;

        public DeleteLogsJob(ILogRepository logRepository, IOptions<DeleteLogsJobOptions> options)
        {
            this._logRepository = logRepository;
            this._amountOfDays = options.Value.AmountOfDays ?? throw new ArgumentException("Amount of days cannot be null");
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var date = DateTime.UtcNow.AddDays(-this._amountOfDays);
            await _logRepository.RemoveLogsAfterPeriodOfTime(date);
        }
    }
}
