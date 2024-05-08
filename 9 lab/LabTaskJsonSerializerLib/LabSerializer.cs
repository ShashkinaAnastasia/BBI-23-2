using System.Text.Json;

namespace LabTaskJsonSerializerLib
{
    public abstract class Serial
    {
        public abstract void Write<T>(T obj, string filePath);
        public abstract T Read<T>(string filePath);
    }
    public class JSSerializer : Serial
    {
        public override void Write<T>(T task, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, task);
            }
        }
        public override T Read<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
            return default(T);
        }
    }
}
