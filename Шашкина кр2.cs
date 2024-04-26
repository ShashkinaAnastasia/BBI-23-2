using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml.Linq;

abstract class Task
{
    protected string text;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}

class Task1: Task
{
    public Task1(string text) : base(text) { }
    public override string ToString()
    {
       

        return text;
    }

}
class Task2: Task
{
    public Task2(string text) : base(text) { }
    public override string ToString()
    {
       
        
        return text;
    }
}
class Json
{
    public static void Write<T>(T task, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, task);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}
class Program
{ static void Main()
    {
        string text = "Hello student :)";

        Task[] tasks = { new Task1(text),
                         new Task2(text) };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2304164\Documents\m2304164";
        string folderName = "Answer";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string folder1 = "cw2_1.json";
        string folder2 = "cw2_2.json";

        folder1 = Path.Combine(path, folder1);
        folder2 = Path.Combine(path, folder2);
        if (!File.Exists(folder1))
        {
            Json.Write<Task1>((Task1)tasks[0], folder1);
        }
        else
        {
            var task1 = Json.Read<Task1>(folder2);
            Console.WriteLine(task1);

        }
        if (!File.Exists(folder2))
        {
            Json.Write<Task2>((Task2)tasks[1], folder2);
        }
        else
        {           
            var task2 = Json.Read<Task2>(folder2);           
            Console.WriteLine(task2);
        }
    }
}