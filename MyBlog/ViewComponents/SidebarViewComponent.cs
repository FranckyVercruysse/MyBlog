using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.View_Models;
using MyBlog.Repositories;

namespace MyBlog.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public SidebarViewComponent(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IViewComponentResult Invoke()
        {
            var widgetViewModel = new WidgetViewModel(_blogRepository);

            return View(widgetViewModel);
        }
    }
}
