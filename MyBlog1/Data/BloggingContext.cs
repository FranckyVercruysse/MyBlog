using Microsoft.EntityFrameworkCore;
using MyBlog1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog1.Data
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
