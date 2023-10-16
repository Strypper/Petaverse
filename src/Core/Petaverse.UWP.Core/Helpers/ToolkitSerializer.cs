using Microsoft.Toolkit.Helpers;
using Newtonsoft.Json;

namespace Petaverse.UWP.Core;

public class ToolkitSerializer : IObjectSerializer
{
    private readonly JsonSerializerSettings settings = new JsonSerializerSettings();

    public T Deserialize<T>(string value)
    {
        var result = JsonConvert.DeserializeObject<T>(value.ToString(), settings);
        return result;
    }

    public string Serialize<T>(T value)
    {
        var result = JsonConvert.SerializeObject(value, typeof(T), Formatting.Indented, settings);
        return result;
    }
}
