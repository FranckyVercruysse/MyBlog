using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.View_Models;
using MyBlog.Repositories;
using System;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ViewResult Posts(int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, p);

            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }

        public ViewResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, category, "Category", p);

            if (viewModel.Category == null)
                throw new Exception("Category not found");

            ViewBag.Title = $@"Latest posts on category ""{viewModel.Category.Name}""";
            return View("List", viewModel);
        }

        public ViewResult Tag(string tag, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, tag, "Tag", p);

            if (viewModel.Tag == null)
                throw new Exception("Tag not found");


            ViewBag.Title = $@"Latest posts tagged on ""{viewModel.Tag.Name}""";

            return View("List", viewModel);
        }

        public ViewResult Search(string s, int p = 1)
        {
            ViewBag.Title = $@"Lists of posts found for search text ""{s}""";

            var viewModel = new ListViewModel(_blogRepository, s, "Search", p);
            return View("List", viewModel);
        }

        public ViewResult Post(int year, int month, string title)
        {
            var post = _blogRepository.Post(year, month, title);

            if (post == null)
                throw new Exception("Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new Exception("The post is not published");

            return View(post);
        }
    }
}