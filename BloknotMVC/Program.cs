using BloknotMVC.Data.Context;
using BloknotMVC.Implementation;
using BloknotMVC.Services;
using Microsoft.EntityFrameworkCore;

namespace BloknotMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BloknotDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddSingleton<ILoggerService, FileLogger>();

            #region
            //if(builder.Environment.IsDevelopment())
            //{
            //    builder.Services.AddSingleton<ILoggerService, DebugLogger>();
            //}
            //else
            //{
            //    builder.Services.AddSingleton<ILoggerService, FileLogger>();
            //}
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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