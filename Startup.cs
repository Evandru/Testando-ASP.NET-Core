using DarkStore.Models;
using DarkStore.Services;
using System.Text.Json;

namespace DarkStore
{
    public class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            var services = builder.Services;

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllers();
            services.AddTransient<JsonFileProductService>();
        }

        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapBlazorHub();
            //app.MapGet("/Products", (context) =>
            //{
            //    var products = ((IApplicationBuilder)app).ApplicationServices.GetService<JsonFileProductsService>().GetProducts();
            //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
            //    return context.Response.WriteAsync(json);
            //}); 

        }
    }
}
