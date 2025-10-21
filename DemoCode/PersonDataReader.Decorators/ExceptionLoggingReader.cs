using PeopleViewer.Common;
using PeopleViewer.Logging;

namespace PersonDataReader.Decorators;

public class ExceptionLoggingReader : IPersonReader
{
    private IPersonReader _wrappedReader;
    private ILogger _logger;

    public ExceptionLoggingReader(IPersonReader wrappedReader,
        ILogger? logger)
    {
        _wrappedReader = wrappedReader;
        _logger = logger ?? new NullLogger();
    }

    public async Task<IReadOnlyCollection<Person>> GetPeople()
    {
        try
        {
            return await _wrappedReader.GetPeople();
        }
        catch (Exception ex)
        {
            await _logger.LogException(ex);
            throw;
        }
    }

    public async Task<Person?> GetPerson(int id)
    {
        try
        {
            return await _wrappedReader.GetPerson(id);
        }
        catch (Exception ex)
        {
            await _logger.LogException(ex);
            throw;
        }
    }
}
