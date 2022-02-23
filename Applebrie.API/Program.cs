using Applebrie.API.Extensions;
using Applebrie.API.Middleware;
using Applebrie.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers().AddNewtonsoftJson(option =>
{
    // to avoid exception "A possible object cycle was detected. This can either be due to a cycle or
    // if the object depth is larger than the maximum allowed depth of 32. Consider using ReferenceHandler....."
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddCustomApplicationService(builder.Configuration);
using (var serviceProvider = services.BuildServiceProvider())
{
    try
    {
        var dataContest = serviceProvider.GetRequiredService<ApplebrieDbContext>();
        await dataContest.Database.MigrateAsync();
        await SeedData.SeedUser(dataContest);
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during Migration");
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();
