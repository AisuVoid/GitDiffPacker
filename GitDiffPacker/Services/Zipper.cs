using System.IO.Compression;

namespace GitDiffPacker.Services
{
    public class Zipper
    {
        public void ZipFolder(string sourceFolder, string zipPath)
        {
            if (File.Exists(zipPath)) File.Delete(zipPath);
            ZipFile.CreateFromDirectory(sourceFolder, zipPath);
        }
    }
}