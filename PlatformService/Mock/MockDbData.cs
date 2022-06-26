using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Mock;

public static class MockDbData
{
    public static void Population(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        MockData(scope.ServiceProvider.GetService<ApplicationDbContext>());
    }

    private static void MockData(ApplicationDbContext context)
    {
        if (context.Platforms.Any()) return;
        context.Platforms.AddRange(
            new Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
            new Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
            new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
            new Platform() { Name = "Kubernetes", Publisher = "Microsoft", Cost = "Free" }
        );
        context.SaveChanges();
    }
}