using Microsoft.EntityFrameworkCore;
using SpeakHub.Domain.Entities.Admins;
using SpeakHub.Domain.Entities.Comments;
using SpeakHub.Domain.Entities.Followers;
using SpeakHub.Domain.Entities.Likes;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            //Database.Migrate();
            //Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Admin> Admins { get; set; } = default!;
        public virtual DbSet<Tweet> Tweets { get; set; } = default!;
        public virtual DbSet<Like> Likes { get; set; } = default!;
        public virtual DbSet<Comment> Comments { get; set; } = default!;
        public virtual DbSet<Follower> Follows { get; set; } = default!;
        public virtual DbSet<Following> Followings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
        }
    }
}
