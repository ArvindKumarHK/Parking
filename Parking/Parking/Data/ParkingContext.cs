using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data;

public partial class ParkingContext : DbContext
{
    public ParkingContext()
    {
    }

    public ParkingContext(DbContextOptions<ParkingContext> options)
        : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Camera> Cameras { get; set; }
    public DbSet<CameraLog> CameraLogs { get; set; }
    public DbSet<Zone> Zones { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\Parking.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
