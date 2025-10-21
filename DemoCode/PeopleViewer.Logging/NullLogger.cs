namespace PeopleViewer.Logging;

public class NullLogger : ILogger
{
    public Task Log(LogLevel level, string message)
    {
        return Task.CompletedTask;
    }
}
