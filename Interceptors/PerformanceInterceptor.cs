using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Catansy.API.Interceptors;

public class PerformanceInterceptor : DbCommandInterceptor
{
    private readonly ILogger<PerformanceInterceptor> _logger;

    public PerformanceInterceptor(ILogger<PerformanceInterceptor> logger)
    {
        _logger = logger;
    }

    public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
    {
        if (eventData.Duration.TotalMilliseconds > 1)
        {
            LogLongQuery(command, eventData);
        }
        return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        if (eventData.Duration.TotalMilliseconds > 1)
        {
            LogLongQuery(command, eventData);
        }
        return base.ReaderExecuted(command, eventData, result);
    }
    
    private void LogLongQuery(DbCommand command, CommandExecutedEventData eventData)
    {
        _logger.LogWarning("Long query:\n{CommandCommandText} \nDuration: {DurationTotalMilliseconds} ms", command.CommandText, eventData.Duration.TotalMilliseconds);
    }
}