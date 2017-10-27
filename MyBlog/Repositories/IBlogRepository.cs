using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Repositories
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();

        Post Post(int year, int month, string titleSlug);
    }
}
