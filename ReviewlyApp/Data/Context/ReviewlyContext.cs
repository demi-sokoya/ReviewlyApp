using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReviewlyApp.Data;

namespace ReviewlyApp.Data.Context
{
    public class ReviewlyContext : DbContext
    {
        public ReviewlyContext(DbContextOptions<ReviewlyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Films> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }
}
