using Newtonsoft.Json;

namespace Movies.API.Helpers
{
    public class Helper : IHelper
    {
        public T? ReadFile<T>(string filePath)      
        {
            var serializer = new JsonSerializer();
            using var r = new StreamReader(filePath);

            using var jsonTextReader = new JsonTextReader(r);

            return serializer.Deserialize<T>(jsonTextReader);
        }
    }
}
