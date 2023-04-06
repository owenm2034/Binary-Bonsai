using System;
using Models.BonsaiTrees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class BonsaiTreeRepository : DbContext
{
    public BonsaiTreeRepository(DbContextOptions<BonsaiTreeRepository> options)
        : base(options)
    {
        using (var connection = new SqliteConnection("Data Source=hello.db")) { }
    }

    public DbSet<Models.BonsaiTrees.BonsaiTree> BonsaiTree { get; set; } = default!;
}
