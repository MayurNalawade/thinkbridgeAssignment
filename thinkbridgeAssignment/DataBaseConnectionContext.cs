using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thinkbridgeAssignment.Model;

namespace thinkbridgeAssignment
{
    public class DataBaseConnectionContext : DbContext
    {
        public DataBaseConnectionContext(DbContextOptions<DataBaseConnectionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }

        public DbSet<Product> products { get; set; }
    }
}
