using PlatformService.Models;

namespace PlatformService.Interfaces;

public interface IRepository
{
    bool SaveChanges();
    IEnumerable<Platform?> GetAllPlatforms();
    Platform? GetPlatformById(int id);
    void CreatePlatform(Platform platform);
}