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