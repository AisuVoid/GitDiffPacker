using GitDiffPacker.Services;
using GitDiffPacker.Utils;
using CommandLine;

class Program
{
    static void Main(string[] args)
    {
        var options = ParseArguments(args);

        var gitService = new GitService();
        var fileCopyService = new FileCopyService();
        var zipper = new Zipper();
        var logger = new ConsoleLogger();

        // Step 1: Get list of changed files
        var changedFiles = gitService.GetChangedFiles(options.RepoPath, options.FromCommit, options.ToCommit);

        // Step 2: Copy changed files to output folder
        string outputFolder = Path.Combine(options.RepoPath, "DiffPack");
        fileCopyService.CopyFiles(changedFiles, options.RepoPath, outputFolder);

        // Step 3: Zip them
        string zipPath = Path.Combine(options.RepoPath, "DiffPack.zip");
        zipper.ZipFolder(outputFolder, zipPath);

        logger.Info($"Pack complete: {zipPath}");
    }

    static Options ParseArguments(string[] args)
    {
        var options = new Options();
        Parser.Default.ParseArguments<Options>(args)
               .WithParsed(parsed => options = parsed)
               .WithNotParsed(errors => {
                   Console.WriteLine("Invalid arguments.");
               });

        return options;
    }
}