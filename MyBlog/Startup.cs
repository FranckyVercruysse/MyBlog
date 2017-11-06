using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data;
using MyBlog.Repositories;

namespace MyBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BloggingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBlogRepository, BlogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Tag",
                    template: "Tag/{tag}",
                    defaults: new { controller = "Blog", action = "Tag" }
                    );

                routes.MapRoute(
                    "Category",
                    "Category/{category}",
                    new { controller = "Blog", action = "Category" }
                    );
                routes.MapRoute(
                    name: "Post",
                    template: "Archive/{year}/{month}/{title}",
                    defaults: new { controller = "Blog", action = "Post" }
                   );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Blog}/{action=Posts}/{id?}"
                    );

            });
        }
    }
}
