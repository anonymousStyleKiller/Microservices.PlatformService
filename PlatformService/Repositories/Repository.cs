using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;

namespace PlatformService.Repositories;

internal class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IEnumerable<Platform?> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform? GetPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(i => i != null && i.Id.Equals(id));
    }

    public void CreatePlatform(Platform platform)
    {
        if (platform is null) throw new ArgumentNullException(nameof(platform));
        _context.Platforms.Add(platform);
    }
}