using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Final.DAL.Contexts
{
    public class FinalDbContext :DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductParameter> ProductParameter { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public FinalDbContext(DbContextOptions<FinalDbContext> options)
     : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinalDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
