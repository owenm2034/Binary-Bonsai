using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoistureSensors;

public class MoistureSensorRecord : DbContext
{
    public MoistureSensorRecord(DbContextOptions<MoistureSensorRecord> options)
        : base(options) { }

    public DbSet<MoistureSensors.MoistureSensor> MoistureSensor { get; set; } = default!;
}
