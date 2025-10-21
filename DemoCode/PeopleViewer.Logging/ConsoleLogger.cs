namespace PeopleViewer.Logging;

public class ConsoleLogger : ILogger
{
    public Task Log(LogLevel level, string message)
    {
        Console.WriteLine($"{DateTimeOffset.Now:u}: {level} - {message}");
        return Task.CompletedTask;
    }

    public Task LogException(Exception ex)
    {
        Console.WriteLine($"{DateTimeOffset.Now:u}: ERROR - {ex.GetType()} - {ex.Message}");
        return Task.CompletedTask;
    }
}
