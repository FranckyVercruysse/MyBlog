using Microsoft.EntityFrameworkCore;
using MyBlog1.Data;
using MyBlog1.Models;
using System.Collections.Generic;
using System.Linq;

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

        public Post Post(int year, int month, string titleSlug)
        {
            var post = _context.Posts
                        .Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Equals(titleSlug))
                        .Include(s => s.PostTags)
                                .ThenInclude(e => e.Tag)
                        .Include(c => c.Category)
                        .Single();
            return post;
        }
    }
}
