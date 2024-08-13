using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CatansyAPI.Interceptors;

public class PerformanceInterceptor : DbCommandInterceptor
{
    public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
    {
        if (eventData.Duration.TotalMilliseconds > 2000)
        {
            LogLongQuery(command, eventData);
        }
        return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        if (eventData.Duration.TotalMilliseconds > 2000)
        {
            LogLongQuery(command, eventData);
        }
        return base.ReaderExecuted(command, eventData, result);
    }
    
    private static void LogLongQuery(DbCommand command, CommandExecutedEventData eventData)
    {
        Console.WriteLine($"Long query: {command.CommandText}. Duration: {eventData.Duration.TotalMilliseconds} ms", LogLevel.Warning);
    }
}