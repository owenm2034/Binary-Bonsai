using Microsoft.Data.Sqlite;

public interface IDatabaseContext
{
    public SqliteConnection _abstractRepository {get; set;}
}
