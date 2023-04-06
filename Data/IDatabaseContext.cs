using Microsoft.Data.Sqlite;

public interface IDatabaseContext
{
    public SqliteConnection db { get; set; }
}
