using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DAL.Configurations;
using ValidationException = DAL.Exceptions.ValidationException;

namespace DAL.Contexts
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SensorConfiguration());
            modelBuilder.ApplyConfiguration(new SensorDataConfiguration());
            modelBuilder.ApplyConfiguration(new LocalPointConfiguration());
        }

        public override int SaveChanges()
        {
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            if (entities.Any(entity => !Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults)))
            {
                throw new ValidationException(validationResults);
            }

            return base.SaveChanges();
        }

    }

}
