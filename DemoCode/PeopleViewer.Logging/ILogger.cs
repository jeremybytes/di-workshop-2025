namespace PeopleViewer.Logging;

public enum LogLevel
{
    None,
    Debug,
    Info,
    Warning,
    Error,
}

public interface ILogger
{
    Task Log(LogLevel level, string message);
    Task LogDebug(string message) => Log(LogLevel.Debug, message);
    Task LogException(Exception ex) => Log(LogLevel.Error, ex.ToString());
}
