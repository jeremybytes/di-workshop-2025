using PeopleViewer.Common;

namespace PersonDataReader.Flaky;

public class FlakyReader : IPersonReader
{
    private int _failureRate;
    private int _count = 0;

    public FlakyReader(int failurePercentage)
    {
        _failureRate = 100 / failurePercentage;
    }

    public Task<IReadOnlyCollection<Person>> GetPeople()
    {
        TryFail();
        return Task.FromResult(people);
    }

    public Task<Person?> GetPerson(int id)
    {
        TryFail();
        return Task.FromResult(people.FirstOrDefault(p => p.Id == id));
    }

    private void TryFail()
    {
        _count++;
        if (_count % _failureRate == 0)
        {
            throw new InsufficientMemoryException("This didn't work");
        }
    }

    private IReadOnlyCollection<Person> people = new List<Person>()
        {
            new Person() {Id = 1,
                GivenName = "John", FamilyName = "Koenig",
                StartDate = new DateTime(1975, 10, 17), Rating = 6},
            new Person() {Id = 2,
                GivenName = "Dylan", FamilyName = "Hunt",
                StartDate = new DateTime(2000, 10, 2), Rating = 8},
            new Person() {Id = 3,
                GivenName = "Leela", FamilyName = "Turanga",
                StartDate = new DateTime(1999, 3, 28), Rating = 8, 
                FormatString = "{1} {0}"},
            new Person() {Id = 4,
                GivenName = "John", FamilyName = "Crichton",
                StartDate = new DateTime(1999, 3, 19), Rating = 7},
            new Person() {Id = 5,
                GivenName = "Dave", FamilyName = "Lister",
                StartDate = new DateTime(1988, 2, 15), Rating = 9},
            new Person() {Id = 6,
                GivenName = "Laura", FamilyName = "Roslin",
                StartDate = new DateTime(2003, 12, 8), Rating = 6},
            new Person() {Id = 7,
                GivenName = "John", FamilyName = "Sheridan",
                StartDate = new DateTime(1994, 1, 26), Rating = 6},
            new Person() {Id = 8,
                GivenName = "Dante", FamilyName = "Montana",
                StartDate = new DateTime(2000, 11, 1), Rating = 5},
            new Person() {Id = 9,
                GivenName = "Isaac", FamilyName = "Gampu",
                StartDate = new DateTime(1977, 9, 10), Rating = 4},
            new Person() {Id = 10,
                GivenName = "Naomi", FamilyName = "Nagata",
                StartDate = new DateTime(2015, 11, 23), Rating = 7},
            new Person() {Id = 11,
                GivenName = "John", FamilyName = "Boon",
                StartDate = new DateTime(1993, 01, 06), Rating = 5},
            new Person() {Id = 12,
                GivenName = "Kerr", FamilyName = "Avon",
                StartDate = new DateTime(1978, 01, 02), Rating = 8},
            new Person() {Id = 13,
                GivenName = "Ed", FamilyName = "Mercer",
                StartDate = new DateTime(2017, 09, 10), Rating = 8},
            new Person() {Id = 14,
                GivenName = "Devon", FamilyName = "",
                StartDate = new DateTime(1973, 09, 23), Rating = 4,
                FormatString = "{0}"},
        };

}
