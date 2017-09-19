using Microsoft.EntityFrameworkCore;
using MyBlog2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog2.Data.Database
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PostTag>()
            //    .HasKey(t => new { t.PostId, t.TagId });

            //modelBuilder.Entity<PostTag>()
            //    .HasOne(pt => pt.Post)
            //    .WithMany(p => p.PostTags)
            //    .HasForeignKey(pt => pt.PostId);

            //modelBuilder.Entity<PostTag>()
            //    .HasOne(pt => pt.Tag)
            //    .WithMany(t => t.PostTags)
            //    .HasForeignKey(pt => pt.TagId);


            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Category>().ToTable("Category");
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
    }
}
