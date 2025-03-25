using EmergencyNavigation.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Edge> Edeges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VertexCharacterization> VertexCharacterizations { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Vertex> Vertices { get; set; }        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Edge>()
                .HasOne(e => e.Source)
                .WithMany(v => v.Edges) 
                .HasForeignKey(e => e.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Edge>()
                .HasOne(e => e.Vertex)
                .WithMany() 
                .HasForeignKey(e => e.VertexId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
