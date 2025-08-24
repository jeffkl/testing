using Newtonsoft.Json;

namespace ProjectWithVulnerabilities;

public class Class1
{
    public string TestJsonSerialization()
    {
        var testObject = new { Message = "Test", Version = "13.0.3" };
        return JsonConvert.SerializeObject(testObject);
    }
}
