using System.IO;

namespace CodeGenerator.LIB.Utils.Connections;

public abstract class IOService<TObject>
{
    protected string DirectoryLocation { get; set; }

    protected string FileName { get; set; } = string.Empty;

    protected string FilePath => Path.Combine(DirectoryLocation, FileName);

    public IOService(string directoryPath)
    {
        if (Directory.Exists(directoryPath) == false)
            Directory.CreateDirectory(directoryPath);

        DirectoryLocation = directoryPath;
    }

    public abstract TObject? Read();

    public abstract bool TryRead(out TObject? result);

    public abstract void Write(TObject? data);
}