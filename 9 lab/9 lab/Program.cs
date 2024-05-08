using LabTaskJsonSerializerLib;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
class Program
{
    class Sportsman
    {
        private string _family;
        private double _rez1;
        private double _rez2;
        private bool _disqualificated;

        public string family{ get { return _family; } }
        public double rez1 { get { return _rez1; } }
        public double rez2 { get { return _rez2; } }
        public bool disqualificated { get { return _disqualificated; } }

        [JsonConstructor]
        public Sportsman(string family, double rez1, double rez2, bool disqualificated)
        {
            _family = family;
            _rez1 = rez1;
            _rez2 = rez2;
            _disqualificated = disqualificated;
        }

        public Sportsman(string family, double rez1, double rez2)
        {
            _family = family;
            _rez1 = rez1;
            _rez2 = rez2;
            _disqualificated = false;
        }

        public void printRez()
        {

            Console.WriteLine(
                "Фамилия {0} \t => 1: {1:f2} \t 2: {2:f2}",
                _family, _rez1, _rez2);
        }
        public void SetDisqualificated()
        {
            _disqualificated = true;
        }
    }

    static bool sp1IsBetterSp2(Sportsman sp1, Sportsman sp2)
    {

        double max1 = Math.Max(sp1.rez1, sp1.rez2);
        double max2 = Math.Max(sp2.rez1, sp2.rez2);


        if (max1 > max2)
            return true;

        if (max1 < max2)
            return false;


        double min1 = Math.Min(sp1.rez1, sp1.rez2);
        double min2 = Math.Min(sp2.rez1, sp2.rez2);

        return min1 > min2;
    }


    static void ShellSort(Sportsman[] sp)
    {
        for (int s = sp.Length / 2; s > 0; s /= 2)
        {
            for (int i = s; i < sp.Length; ++i)
            {
                for (int j = i - s; j >= 0 && !sp1IsBetterSp2(sp[j], sp[j + s]); j -= s)
                {
                    Sportsman temp = sp[j];
                    sp[j] = sp[j + s];
                    sp[j + s] = temp;
                }
            }
        }
    }




    static void Main()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Shashkina", "Lab9_1");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        Sportsman[] sp = new Sportsman[5];
        string[] s = new string[] { "Иванов", "Петров", "Стопов", "Борцов", "Носков" };
        double[] r1 = new double[] { 1.50, 1.55, 1.47, 1.46, 1.54 };
        double[] r2 = new double[] { 1.55, 1.40, 1.42, 1.60, 1.20 };

        for (int i = 0; i < sp.Length; i++)
            sp[i] = new Sportsman(s[i], r1[i], r2[i]);

        string jsonFile = Path.Combine(path, "lab9_1.json");
        JSSerializer serializer = new JSSerializer();

        serializer.Write<Sportsman[]>(sp, jsonFile);
        Sportsman[] spFromFile = serializer.Read<Sportsman[]>(jsonFile);

        for (int i = 0; i < sp.Length; i++)
            spFromFile[i].printRez();

        ShellSort(spFromFile);

        Console.WriteLine();
        for (int i = 0; i < spFromFile.Length; i++)
            spFromFile[i].printRez();

        spFromFile[2].SetDisqualificated();

        Console.WriteLine();
        for (int i = 0; i < spFromFile.Length; i++)
            if (!(spFromFile[i].disqualificated))
                spFromFile[i].printRez();
    }
}
