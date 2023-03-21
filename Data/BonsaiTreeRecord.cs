using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BonsaiTrees;

    public class BonsaiTreeContext : DbContext
    {
        public BonsaiTreeContext (DbContextOptions<BonsaiTreeContext> options)
            : base(options)
        {
        }

        public DbSet<BonsaiTrees.BonsaiTree> BonsaiTree { get; set; } = default!;
    }
