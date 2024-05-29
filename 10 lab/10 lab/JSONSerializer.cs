using System.Xml.Serialization;
using Newtonsoft.Json;

public abstract class MySerializer
{
    public abstract void Write<T>(T obj, string filePath);
    public abstract T Read<T>(string filePath);
}

public class MyJsonSerializer : MySerializer
{
    public override void Write<T>(T obj, string filePath)
    {
        using (StreamWriter writer = File.CreateText(filePath))
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            writer.Write(json);
        }
    }
    public override T Read<T>(string filePath)
    {
        using (StreamReader reader = File.OpenText(filePath))
        {
            string json = reader.ReadToEnd();
            T result = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return result;
        }
    }
}

public class MyXmlSerializer : MySerializer
{
    public override void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            new XmlSerializer(typeof(T)).Serialize(fs, obj);
        }
    }
    public override T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(fs);
        }
    }   
}
