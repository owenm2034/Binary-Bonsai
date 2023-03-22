using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.BonsaiTrees;

    public class BonsaiTreeRecord : DbContext
    {
        public BonsaiTreeRecord (DbContextOptions<BonsaiTreeRecord> options)
            : base(options)
        {
        }

        public DbSet<Models.BonsaiTrees.BonsaiTree> BonsaiTree { get; set; } = default!;
    }
