using FA.JustBlog.Models.BaseEntities;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Models.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FA.JustBlog.Data
{
    public class JustBlogContext : IdentityDbContext<User>
    {
        public JustBlogContext() : base("JustBlogCnn")
        {
        }

        static JustBlogContext()
        {
            Database.SetInitializer<JustBlogContext>(new DbInitializer());
        }

        public static JustBlogContext Create()
        {
            return new JustBlogContext();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(m =>
                {
                    m.MapLeftKey("PostId");
                    m.MapRightKey("TagId");
                    m.ToTable("PostTags", "common");
                });
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            BeforeSaveChanges();
            return await base.SaveChangesAsync();
        }

        private void BeforeSaveChanges()
        {
            var entities = this.ChangeTracker.Entries();
            foreach (var entry in entities)
            {
                if (entry.Entity is IBaseEntity entityBase)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified: entityBase.UpdatedAt = DateTime.Now; break;
                        case EntityState.Added:
                            entityBase.UpdatedAt = DateTime.Now;
                            entityBase.InsertedAt = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
