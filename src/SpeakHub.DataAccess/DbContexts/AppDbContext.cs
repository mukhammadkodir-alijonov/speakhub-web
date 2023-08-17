using Microsoft.EntityFrameworkCore;
using SpeakHub.Domain.Entities.Admins;
using SpeakHub.Domain.Entities.Likes;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = default!;
        public virtual DbSet<Admin> Admins { get; set; } = default!;
        public virtual DbSet<Tweet> Tweets { get; set; } = default!;
        public virtual DbSet<Like> Likes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
        }
    }
}
