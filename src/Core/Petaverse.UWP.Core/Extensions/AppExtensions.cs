using System.Threading.Tasks;
using Windows.Storage;

namespace Petaverse.UWP.Core;

public static class AppExtensions
{
    public static async Task<StorageFile> CreateTempCopyAsync(this StorageFile file)
    {
        StorageFolder destination = ApplicationData.Current.TemporaryFolder; // here?
        // Keep the same extension
        var filename = $"{Guid.NewGuid()}.{System.IO.Path.GetExtension(file.Name)}";
        return await file.CopyAsync(destination, filename, NameCollisionOption.GenerateUniqueName);
    }
}
