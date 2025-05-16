using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DataAccessLayer.Data.Seeds;
using BusinessLogicLayer.Data;
using DataAccessLayer.Models.EntityAbstractions;
using DataAccessLayer.Models.Enums;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Audit> Audit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().GenarateUserSeed();
            modelBuilder.Entity<Category>().GenerateCategorySeed();
            modelBuilder.Entity<Product>().GenerateProductSeed();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<double>().HaveColumnType("numeric(18, 2)");
        }

        public virtual async Task<int> SaveChangesAsync(string? userId = null)
        {
            OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        private void OnBeforeSaveChanges(string? userId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = userId ?? "Unknown"
                };
                auditEntries.Add(auditEntry);

                var isDeletedProperty = entry.Properties.FirstOrDefault(prop => prop.Metadata.Name == nameof(AuditableEntity.IsDeleted));
                if (!Equals(isDeletedProperty?.OriginalValue, isDeletedProperty?.CurrentValue))
                {
                    auditEntry.AuditType = AuditTypeEnum.Delete;

                    auditEntry.KeyValues = entry.Properties
                        .Where(prop => prop.Metadata.IsPrimaryKey())
                        .ToDictionary(prop => prop.Metadata.Name, prop => prop.CurrentValue);

                    auditEntry.OldValues = entry.Properties
                        .Where(p => !IsTrackableProperty(p))
                        .ToDictionary(p => p.Metadata.Name, p => p.OriginalValue);

                    continue;
                }

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;

                    if (IsTrackableProperty(property))
                        continue;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        if (entry.State != EntityState.Added || entry.Entity is not BaseEntity)
                        {
                            auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        }
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditTypeEnum.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditTypeEnum.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (!property.IsModified)
                                break;

                            auditEntry.AuditType = AuditTypeEnum.Update;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            if (!Equals(property.OriginalValue, property.CurrentValue))
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                            }
                            break;
                    }
                }
            }

            foreach (var auditEntry in auditEntries)
            {
                Audit.Add(auditEntry.ToAudit());
            }
        }

        private static bool IsTrackableProperty(PropertyEntry property) =>
            property.Metadata.Name is
                nameof(AuditableEntity.CreationDate) or
                nameof(AuditableEntity.ModificationDate) or
                nameof(AuditableEntity.DeletionDate) or
                nameof(AuditableEntity.IsDeleted);
    }
}
