﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog1.Models;
using MyBlog1.Data;
using Microsoft.EntityFrameworkCore;

namespace MyBlog1.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private BloggingContext _context;
        public BlogRepository(BloggingContext context)
        {
            _context = context;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _context.Posts
                  .Where(p => p.Published)
                  .OrderByDescending(p => p.PostedOn)
                  .Skip(pageNo * pageSize)
                  .Take(pageSize)
                  .Include(s => s.PostTags)
                        .ThenInclude(e => e.Tag)
                  .Include(c => c.Category)
                  .AsNoTracking()
                  .ToList();

            return posts;
        }

        public int TotalPosts()
        {
            return _context.Posts.Where(p => p.Published).Count();
        }
    }
}