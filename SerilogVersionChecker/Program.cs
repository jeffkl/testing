using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace SerilogVersionChecker;

class Program
{
    static async Task Main(string[] args)
    {
        string packageId = "Serilog";
        
        Console.WriteLine($"Checking latest version of {packageId}...");
        
        try
        {
            var latestVersion = await GetLatestPackageVersionAsync(packageId);
            
            if (latestVersion != null)
            {
                Console.WriteLine($"Latest version of {packageId}: {latestVersion}");
            }
            else
            {
                Console.WriteLine($"Could not find package: {packageId}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static async Task<string?> GetLatestPackageVersionAsync(string packageId)
    {
        var logger = NullLogger.Instance;
        var cancellationToken = CancellationToken.None;
        
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<FindPackageByIdResource>();
        
        var versions = await resource.GetAllVersionsAsync(
            packageId,
            new SourceCacheContext(),
            logger,
            cancellationToken);
        
        var latestVersion = versions
            .Where(v => !v.IsPrerelease)
            .OrderByDescending(v => v, VersionComparer.VersionRelease)
            .FirstOrDefault();
        
        return latestVersion?.ToNormalizedString();
    }
}
