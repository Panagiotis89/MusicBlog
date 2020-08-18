using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Data.Configuration
{
   public class MyMusicDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //we say that when a Post is deleted, then delete related Comments
            builder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post)
                .OnDelete(DeleteBehavior.Cascade);

            //we configure the relationship by not specifing any navigation property
            //on Music side, because we do not need it. We do it to say that there is
            //ne to many relationship and use this ForeignKey
            builder.Entity<Post>()
                .HasOne(m => m.Music)
                .WithMany()
                .HasForeignKey(m => m.MusicId);

            builder.ApplyConfiguration(new MusicConfiguration());

            builder.ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
