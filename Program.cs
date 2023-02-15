using PLTest.Models;
using PLTest.Models.ML;
namespace PLTest {
    public class Program {
        public static void Main(string[] args)
        {
            PLTestConfiguration.Init_Data();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.Lifetime.ApplicationStopping.Register(PLTestConfiguration.SaveConfig);
            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/error?code={0}");
            app.MapControllerRoute
            (
                name: "default",
                pattern: "{controller=Main}/{action=Index}/{id?}"
            );
            app.Run();
        }
    }
}