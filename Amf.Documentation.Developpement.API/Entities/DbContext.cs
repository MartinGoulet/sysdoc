﻿using Microsoft.EntityFrameworkCore;

namespace Amf.Documentation.Developpement.API.Entities
{
    public class DeveloppementContext : DbContext
    {
        public DeveloppementContext(DbContextOptions<DeveloppementContext> options) : base(options) { }

        public DbSet<MachineVirtuelle> MachineVirtuelles { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<MachineVirtuelle>()
        //         .HasKey(c => c.Id);
        // }
    }
}