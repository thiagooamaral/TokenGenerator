namespace TokenGenerator.Infra.Contexts
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CustomerCard> CustomerCard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerCard>().Property(x => x.Id);
            modelBuilder.Entity<CustomerCard>().Property(x => x.CustomerId);
            modelBuilder.Entity<CustomerCard>().Property(x => x.CardNumber);
            modelBuilder.Entity<CustomerCard>().Property(x => x.Cvv);
            modelBuilder.Entity<CustomerCard>().Property(x => x.Token);
            modelBuilder.Entity<CustomerCard>().Property(x => x.RegistrationDate);
        }
    }
}