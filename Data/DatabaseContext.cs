using Microsoft.Data.Sqlite;

namespace DatabaseContexts
{
    public class DatabaseContext : IDatabaseContext
    {
        public SqliteConnection db { get; set; }

        public DatabaseContext(string dbName)
        {
            db = new SqliteConnection(dbName);
        }
    }
}
