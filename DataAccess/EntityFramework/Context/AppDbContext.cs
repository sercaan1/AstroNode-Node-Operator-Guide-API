using Core.Entities.Abstracts;
using Core.Enums;
using Entity.Concrete;
using Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Context
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IMapper).Assembly);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                SetIfAdded(entry);
                SetIfModified(entry);
                SetIfDeleted(entry);
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.Status = Status.Active;
                entityEntry.Entity.CreatedDate = DateTime.Now;
                entityEntry.Entity.CreatedBy = _contextAccessor.HttpContext?.User.Identity.Name ?? "Non-User";
            }
        }

        private void SetIfModified(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Status = Status.Modified;
            }
            entityEntry.Entity.ModifiedDate = DateTime.Now;
            entityEntry.Entity.ModifiedBy = _contextAccessor.HttpContext?.User.Identity.Name ?? "Non-User";
        }
        private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State != EntityState.Deleted)
            {
                return;
            }

            if (entityEntry.Entity is AuditableEntity)
            {
                entityEntry.State = EntityState.Modified;
                entityEntry.Entity.Status = Status.Passive;
                (entityEntry.Entity as AuditableEntity).DeletedDate = DateTime.Now;
                (entityEntry.Entity as AuditableEntity).DeletedBy = _contextAccessor.HttpContext.User.Identity.Name;
            }
        }
    }
}
