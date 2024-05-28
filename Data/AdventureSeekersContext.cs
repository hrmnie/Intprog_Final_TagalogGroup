using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdventureSeekers.Models;
using static NuGet.Packaging.PackagingConstants;

namespace AdventureSeekers.Data
{
    public class AdventureSeekersContext : DbContext
    {
        public AdventureSeekersContext (DbContextOptions<AdventureSeekersContext> options)
            : base(options)
        {
        }

        public DbSet<AdventureSeekers.Models.User_Seeker> User_Seeker { get; set; } = default!;
        public DbSet<AdventureSeekers.Models.User_Post> User_Post { get; set; } = default!;
        public DbSet<AdventureSeekers.Models.Comment> Comments { get; set; } = default!;
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User_Seeker>()
                .HasMany(c => c.User_Post)
                .WithOne(o => o.User_Seekers)
                .HasForeignKey(o => o.seeker_id);

            modelBuilder.Entity<User_Post>()
             .HasMany(c => c.Comments)
             .WithOne(o => o.User_Post)
             .HasForeignKey(o => o.post_id);

           

        }
    }
}
