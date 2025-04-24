using CommandLine;

public class Options
{
    [Option("repo", Required = true)]
    public string RepoPath { get; set; }

    [Option("from", Required = true)]
    public string FromCommit { get; set; }

    [Option("to", Required = true)]
    public string ToCommit { get; set; }
}