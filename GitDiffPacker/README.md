
# GitDiffPacker 🧳

A simple CLI tool to pack changed files between two Git commits into a zip file.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/GitDiffPacker.git
   cd GitDiffPacker
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

## Usage

You can use the `GitDiffPacker` tool to pack files that have changed between two specific Git commits into a zip file.

```bash
dotnet run -- --repo "/path/to/your/repo" --from abc123 --to def456
```

### Options

- `--repo` : The path to the Git repository.
- `--from` : The commit hash to start comparing from.
- `--to` : The commit hash to compare to.

### Example

```bash
dotnet run -- --repo "/Users/yourname/Projects/YourRepo" --from abc123 --to def456
```

This will:
1. Compare the files between commit `abc123` and `def456`.
2. Copy the changed files to a temporary folder.
3. Create a zip archive called `DiffPack.zip` containing the changed files.

## Project Structure

The project is organized into the following folders:

- **GitDiffPacker.csproj** - The project file.
- **Program.cs** - The main entry point for the application.
- **Services/** - Contains logic for interacting with Git, file copying, and zipping.
  - **GitService.cs** - Handles Git operations (fetching changed files).
  - **FileCopyService.cs** - Manages copying of changed files to a new directory.
  - **Zipper.cs** - Handles zipping of files into a zip archive.
- **Models/** - Contains models used throughout the application.
  - **Options.cs** - Defines the command-line options structure.
- **Utils/** - Utility classes for additional functionality.
  - **ConsoleLogger.cs** - Manages logging output to the console.

## Additional Setup

If you haven't installed the **.NET SDK** yet, you can download it from [here](https://dotnet.microsoft.com/download).

---

### Future Enhancements
This project can be extended with new features like:
- Support for compressing multiple file types.
- Integration with Git API via HTTP for more advanced Git operations.
- More user-friendly commands or options in the future.
