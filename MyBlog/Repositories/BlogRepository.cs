using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Repositories
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
                        .AsNoTracking()
                        .Single();
            return post;
        }

        public IList<Category> Categories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            var posts = _context.Posts
                        .Where(p => p.Published & p.Category.UrlSlug.Equals(categorySlug))
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

        public int TotalPostsForCategory(string categorySlug)
        {
            return _context.Posts
                .Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                .Count();
        }

        public Category Category(string categorySlug)
        {
            return _context.Categories
                    .FirstOrDefault(c => c.UrlSlug.Equals(categorySlug));
        }

        public IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            var posts = _context.Posts
                        .Where(p => p.Published && p.PostTags.Any(t => t.Tag.UrlSlug.Equals(tagSlug)))
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

        public int TotalPostsForTag(string tagSlug)
        {
            return _context.Posts
                     .Where(p => p.Published && p.PostTags.Any(t => t.Tag.UrlSlug.Equals(tagSlug)))
                     .Count();
        }

        public Tag Tag(string tagSlug)
        {
            return _context.Tags
                    .FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }

        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            var posts = _context.Posts
                        .Where(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.PostTags.Any(t => t.Tag.Name.Equals(search))))
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

        public int TotalPostsForSearch(string search)
        {
            return _context.Posts
                .Where(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.PostTags.Any(t => t.Tag.Name.Equals(search))))
                .Count();
        }

        public IList<Tag> Tags()
        {
            return _context.Tags.OrderBy(p => p.Name).ToList(); 
        }
    }
}
