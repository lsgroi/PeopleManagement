using Microsoft.EntityFrameworkCore;

namespace PeopleManagement.Data
{
    public class PeopleManagementContext : DbContext
    {
        public PeopleManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.DateAdded).HasDefaultValueSql("GETDATE()");
                entity.HasOne(e => e.Group).WithMany(e => e.People).IsRequired();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(e => e.People).WithOne(e => e.Group).IsRequired();
            });
        }
    }
}
