using Newtonsoft.Json;
using System;
using System.IO;

namespace CodeGenerator.LIB.Utils.Connections;

public class JsonIOService<TObject> : IOService<TObject>
{
    private JsonSerializerSettings _settings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Formatting = Formatting.Indented
    };

    public JsonIOService(string directoryPath, string fileName) : base(directoryPath)
    {
        FileName = fileName;

        if (Path.GetExtension(FilePath) != ".json")
            throw new FileLoadException();

        if (File.Exists(FilePath) == false)
            File.Create(FilePath);
    }

    public override TObject? Read()
        => JsonConvert.DeserializeObject<TObject?>(File.ReadAllText(FilePath), _settings) ?? throw new NullReferenceException();

    public override void Write(TObject? data)
        => File.WriteAllText(FilePath, JsonConvert.SerializeObject(data, _settings));

    public override bool TryRead(out TObject? result)
    {
        result = default;
        try
        {
            result = Read();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
