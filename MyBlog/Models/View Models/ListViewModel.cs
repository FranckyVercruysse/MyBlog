using MyBlog.Repositories;
using System.Collections.Generic;

namespace MyBlog.Models.View_Models
{
    public class ListViewModel
    {
        const int postsPerPage = 3;

        public ListViewModel(IBlogRepository _blogRepository, int p)
        {
            // pick latest 3 (postsPerPage) posts
            Posts = _blogRepository.Posts(p - 1, postsPerPage);
            TotalPosts = _blogRepository.TotalPosts();
        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
    }
}
