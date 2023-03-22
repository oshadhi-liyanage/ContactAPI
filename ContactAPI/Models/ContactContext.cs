namespace ContactAPI.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Configuration;
    using System.Threading;

    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        private readonly IConfiguration _configuration;

        public string DbPath { get; }

        public ContactContext(DbContextOptions<ContactContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        // This method has the `async` modifier, so `await` can be used:
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if(entityEntry.State== EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreationTimestamp =  DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                }
                else
                {
                    ((BaseEntity)entityEntry.Entity).CreationTimestamp = ((BaseEntity)entityEntry.Entity).CreationTimestamp;
                }
                ((BaseEntity)entityEntry.Entity).LastChangeTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseNpgsql(_configuration.GetValue<String>("ContactContext"));

    }
}
