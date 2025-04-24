using System;
using System.Diagnostics;

namespace GitDiffPacker.Services
{
    public class GitService
    {
        public List<string> GetChangedFiles(string repoPath, string fromCommit, string toCommit)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"diff --name-only {fromCommit} {toCommit}",
                WorkingDirectory = repoPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(psi)!;
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output.Split('\n')
                         .Select(line => line.Trim())
                         .Where(line => !string.IsNullOrEmpty(line))
                         .ToList();
        }
    }
}

