using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog1.Repositories;
using MyBlog1.Models.View_Models;

namespace MyBlog1.Controllers
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

    }
}