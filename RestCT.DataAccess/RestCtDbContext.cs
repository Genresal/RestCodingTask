using Microsoft.EntityFrameworkCore;
using RestCT.Shared.Models;

namespace RestCT.DataAccess
{
    public class RestCtDbContext : DbContext
    {
        //Add-Migration InitialCreate
        public RestCtDbContext(DbContextOptions<RestCtDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Items)
                .HasForeignKey(z => z.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}