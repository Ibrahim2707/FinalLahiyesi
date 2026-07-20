using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Contexts
{
    public class FinalDbContext :DbContext
    {
        public DbSet<Slider> Sliders { get; set; }

        public FinalDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinalDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
