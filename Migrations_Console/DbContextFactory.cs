using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyBlog2.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations_Console
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        public BloggingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BloggingContext>();
            builder.UseSqlServer("Server=(local)\\mssqllocaldb;Database=MyBlog2;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new BloggingContext(builder.Options);
        }
    }
}
