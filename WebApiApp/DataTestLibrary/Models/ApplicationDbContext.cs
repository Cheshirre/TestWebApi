using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Data> Datas { get; set; }
        public DbSet<SubData> SubDatas { get; set; }
        public DbSet<Property1> Property1s { get; set; }
        public DbSet<Property2> Property2s { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>()
                .HasMany(c => c.SubData)
                .WithOne(e => e.Data);
        }

    }
}
