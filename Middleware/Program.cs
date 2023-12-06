namespace Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.Map("/map1", HandleMapTest1);

            app.Map("/map2", HandleMapTest2);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from non-Map delegate.");
            });

            app.Run();

            static void HandleMapTest1(IApplicationBuilder app)
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Map Test 1");
                });
            }

            static void HandleMapTest2(IApplicationBuilder app)
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Map Test 2");
                });
            }
        }
    }
}
