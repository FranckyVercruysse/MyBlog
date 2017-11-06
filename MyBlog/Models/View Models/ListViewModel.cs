using MyBlog.Repositories;
using System.Collections.Generic;

namespace MyBlog.Models.View_Models
{
    public class ListViewModel
    {
        ////const int postsPerPage = 3;

        public ListViewModel(IBlogRepository _blogRepository, int p)
        {
            // pick latest 3 (postsPerPage) posts
            Posts = _blogRepository.Posts(p - 1, postsPerPage);
            TotalPosts = _blogRepository.TotalPosts();
        }

        public ListViewModel(IBlogRepository blogRepository,
         string text, string type, int p)
        {
            switch (type)
            {
                case "Category":
                    Posts = blogRepository.PostsForCategory(text, p - 1, postsPerPage);
                    TotalPosts = blogRepository.TotalPostsForCategory(text);
                    Category = blogRepository.Category(text);
                    break;
                case "Tag":
                    Posts = blogRepository.PostsForTag(text, p - 1, postsPerPage);
                    TotalPosts = blogRepository.TotalPostsForTag(text);
                    Tag = blogRepository.Tag(text);
                    break;
                default:
                    Posts = blogRepository.PostsForSearch(text, p - 1, postsPerPage);
                    TotalPosts = blogRepository.TotalPostsForSearch(text);
                    Search = text;
                    break;
            }
        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set; }
        public Tag Tag { get; private set; }
        public string Search { get; private set; }

        private int postsPerPage = 3;
        public int PostsPerPage
        {
            get
            {
                return postsPerPage;   // Don't do this
            }
        }
    }
}
