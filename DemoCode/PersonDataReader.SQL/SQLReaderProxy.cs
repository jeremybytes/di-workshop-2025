using PeopleViewer.Common;

namespace PersonDataReader.SQL;

public class SQLReaderProxy : IPersonReader
{
    public async Task<IReadOnlyCollection<Person>> GetPeople()
    {
        using var reader = new SQLReader();
        return await reader.GetPeople();
    }

    public async Task<Person?> GetPerson(int id)
    {
        using var reader = new SQLReader();
        return await reader.GetPerson(id);
    }

    public string GetTypeName() => $"{this.GetType().Name} ({nameof(SQLReader)})";
}
