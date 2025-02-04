using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TODO.Context;
using TODO.Repositories;
using TODO.Repositories.Interfaces;

namespace TODO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TodoDbContext>(opts =>
             opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            builder.Services.AddTransient<ITasksRepository, TasksRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
