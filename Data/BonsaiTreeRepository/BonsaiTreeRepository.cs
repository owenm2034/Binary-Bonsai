using System;
using Models.BonsaiTrees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using DatabaseContexts;

public class BonsaiTreeRepository : DatabaseContext
{
    public BonsaiTreeRepository(string dbName)
    {
        db = new SqliteConnection(dbName);
    }
}
