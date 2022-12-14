using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// services container

            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddIdentityServices(builder.Configuration);

// middleware
var app = builder.Build();

 app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            


// namespace API
// {
//     public class Program
//     {
//         public static async Task Main(string[] args)
//         {
//          var host = CreateHostBuilder(args).Build();
//          using var scope = host.Services.CreateScope();
//          var services = scope.ServiceProvider;
//          try
//          {
//             var context = services.GetRequiredService<DataContext>();
//             await context.Database.MigrateAsync();
//             await Seed.SeedUsers(context);
//          }
//          catch(Exception ex)
//          {
//             var logger = services.GetRequiredService<ILogger<Program>>();
//             logger.LogError(ex, "An error occured during migration");
//          }
//          await host.RunAsync();
//         }

//         public static IHostBuilder CreateHostBuilder(string[] args) =>
//             Host.CreateDefaultBuilder(args)
//                 .builder.ConfigurationureWebHostDefaults(webBuilder =>
//                 {
//                     webBuilder.UseStartup<Startup>();
//                 });
//     }
// }
