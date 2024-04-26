using System.IO.Compression;

namespace AutoInstallArchSoft.Models;

public class AutoInstallAlgorithm
{
    public string PathToArchiveFolder{ get; set; }
    public List<string> PathsToTargetFolders { get; set; } = new List<string>();
    
    public async Task Start()
    {
        await Task.Factory.StartNew(() =>
        {
            foreach (var file in PathsToTargetFolders)
            {
                ZipFile.ExtractToDirectory(PathToArchiveFolder, file, true);
            }
        });
    }
}