using System;
using Models.BonsaiTrees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class BonsaiTreeRepository
{
    public IDatabaseContext _abstractRepository;

    public BonsaiTreeRepository()
    {

    }

    public DbSet<Models.BonsaiTrees.BonsaiTree> BonsaiTree { get; set; } = default!;
}
