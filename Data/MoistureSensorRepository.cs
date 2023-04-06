using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using Models.MoistureSensors;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


public class MoistureSensorRepository : DbContext
{
    public MoistureSensorRepository (DbContextOptions<BonsaiTreeRepository> options)
            : base(options)
        {
        }

        public DbSet<Models.BonsaiTrees.BonsaiTree> BonsaiTree { get; set; } = default!;
}
