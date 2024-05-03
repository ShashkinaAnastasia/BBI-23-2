using System;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

public abstract class Task
{
    protected string text;
    public Task(string _text)
    {
        text = _text;
    }
}

public class Task1 : Task
{
    public override string ToString()
    {
        Dictionary<char, int> charCounter = new Dictionary<char, int>();

        int totalAlphas = 0;
        for (int index = 0; index < text.Length; ++index)
        {
            char c = char.ToLower(text[index]);
            if (!char.IsLetter(c))
                continue;
            if (charCounter.ContainsKey(c))
                ++charCounter[c];
            else
                charCounter.Add(c, 1);
            ++totalAlphas;
        }

        StringBuilder result = new StringBuilder();
        foreach (KeyValuePair<char, int> kvp in charCounter)
        {
            if (kvp.Key >= 'а' && kvp.Key <= 'я')
            {
                result.Append($"{kvp.Key} = {((double)kvp.Value * 100 / totalAlphas).ToString("00.00")}%\n");
            }
        }
        return result.ToString();
    }

    public Task1(string _text)
        : base(_text)
    {
    }
}

public class Task3 : Task
{
    public override string ToString()
    {

        string stringStart = "";
        string currentWord = "";
        StringBuilder result = new StringBuilder();
        for (int index = 0; index < text.Length; ++index)
        {
            char c = text[index];
            if (c != ' ')
            {
                currentWord += c;
                continue;
            }
            if (currentWord.Length > 50)
            {
                result.AppendLine(currentWord);
                currentWord = "";
                continue;
            }
            if (stringStart.Length + currentWord.Length + 1 > 50)
            {
                result.AppendLine(stringStart);
                stringStart = currentWord;
                currentWord = "";
                continue;
            }

            if (stringStart == "")
                stringStart = currentWord;
            else
                stringStart += ' ' + currentWord;

            currentWord = "";
        }

        if (stringStart.Length + currentWord.Length + 1 > 50)
        {
            result.AppendLine(stringStart);
            result.AppendLine(currentWord);
        }
        else
        {
            result.AppendLine(stringStart + ' ' + currentWord);
        }

        return result.ToString();
    }
    public Task3(string _text)
        : base(_text)
    {
    }
}

public class Task5 : Task
{
    public override string ToString()
    {
        Dictionary<char, int> charCounter = new Dictionary<char, int>();

        int totalAlphas = 0;
        for (int index = 0; index < text.Length; ++index)
        {
            char c = char.ToLower(text[index]);
            if (!char.IsLetter(c))
                continue;
            if (charCounter.ContainsKey(c))
                ++charCounter[c];
            else
                charCounter.Add(c, 1);
            ++totalAlphas;
        }

        List<KeyValuePair<char, int>> sortedChars = charCounter.ToList();
        sortedChars.Sort((x, y) => y.Value.CompareTo(x.Value));


        StringBuilder result = new StringBuilder();
        foreach (KeyValuePair<char, int> kvp in sortedChars)
        {
            if ((kvp.Key >= 'А' && kvp.Key <= 'Я')
             || (kvp.Key >= 'а' && kvp.Key <= 'я'))
            {
                result.AppendLine($"{kvp.Key} = {((double)kvp.Value * 100 / totalAlphas).ToString("00.00")}%");
            }
        }
        return result.ToString();
    }
    public Task5(string _text)
        : base(_text)
    {
    }
}

public class Task7 : Task
{
    protected string subText;
    public override string ToString()
    {
        string currentWord = "";
        StringBuilder result = new StringBuilder();
        for (int index = 0; index < text.Length; ++index)
        {
            char c = text[index];
            if (c != ' ')
            {
                currentWord += c;
                continue;
            }

            for (int index2 = 0; index2 < currentWord.Length - subText.Length; ++index2)
            {
                string subString = currentWord.Substring(index2, subText.Length);
                if (subString == subText)
                {
                    result.AppendLine(currentWord);
                    break;
                }

            }
            currentWord = "";
        }

        for (int index2 = 0; index2 < currentWord.Length - subText.Length; ++index2)
        {
            string subString = currentWord.Substring(index2, subText.Length);
            if (subString == subText)
            {
                result.AppendLine(currentWord);
                break;
            }
        }
        return result.ToString();
    }
    public Task7(string _text, string _subText)
        : base(_text)
    {
        subText = _subText;
    }
}

public class Task11 : Task
{
    public override string ToString()
    {
        string currentWord = "";
        List<string> result = new List<string>();
        for (int index = 0; index < text.Length; ++index)
        {
            char c = text[index];
            if (c != ',')
            {
                currentWord += c;
                continue;
            }
            result.Add(currentWord);

            currentWord = "";
        }
        if (currentWord != "")
            result.Add(currentWord);
        
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < result.Count - 1; i++)
            {
                bool needSwap = false;
                for (int j = 0; j < Math.Min(result[i].Length, result[i + 1].Length); j++)
                {
                    if (result[i][j] > result[i + 1][j])
                    {
                        needSwap = true;
                        break;
                    }
                    else if (result[i][j] < result[i + 1][j])
                    {
                        break;
                    }
                }

                if (needSwap)
                {
                    string temp = result[i];
                    result[i] = result[i + 1];
                    result[i + 1] = temp;
                    swapped = true;
                }
            }
        }
        while (swapped);



        StringBuilder stringBuilder = new StringBuilder();
        foreach (string Name in result)
            stringBuilder.AppendLine(Name);

        return stringBuilder.ToString();
    }
    public Task11(string _text)
        : base(_text)
    {
    }
}

public class Task14 : Task
{
    public override string ToString()
    {
       
        int sum = 0;
        int currentNumber = 0;
        bool isNegative = false;
        for (int index = 0; index < text.Length; ++index)
        {
            char c = text[index];
            if (char.IsDigit(c))
            {
                if (currentNumber == 0)
                {
                    if (index > 0 && text[index - 1] == '-')
                        isNegative = true;
                }

                int number = int.Parse(c.ToString());
                currentNumber *= 10;
                currentNumber += number;
            }
            else
            {
                if (Math.Abs(currentNumber) >= 1 && Math.Abs(currentNumber) <= 9)
                    sum += (currentNumber * (isNegative ? -1 : 1));

                currentNumber = 0;
                isNegative = false;
            }

        }
        return sum.ToString();
    }
    public Task14(string _text)
        : base(_text)
    {
    }
}


class Program
{
    static void Main()
    {
        string text = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";

        Task1 task1 = new Task1(text);
        string report = task1.ToString();
        Console.WriteLine("task 1");
        Console.WriteLine(report);

        Task3 task3 = new Task3(text);
        report = task3.ToString();
        Console.WriteLine("task 3");
        Console.WriteLine(report);

        Task5 task5 = new Task5(text);
        report = task5.ToString();
        Console.WriteLine(" ");
        Console.WriteLine("task 5");
        Console.WriteLine(report);

        Task7 task7 = new Task7(text, "great");
        report = task7.ToString();
        Console.WriteLine(" ");
        Console.WriteLine("task 7");
        Console.WriteLine(report);


        text = "Иванов,Петров,Смирнов,Соколов,Кузнецов,Попов,Лебедев,Волков,Козлов,Новиков,Иванова,Петрова,Смирнова,Ivanov,Petrov,Smirnov,Sokolov,Kuznetsov,Popov,Lebedev,Volkov,Kozlov,Novikov,Ivanova,Petrova,Smirnova";
        Task11 task11 = new Task11(text);
        report = task11.ToString();
        Console.WriteLine(" ");
        Console.WriteLine("task 11");
        Console.WriteLine(report);


        Task14 task14 = new Task14("William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.");
        report = task14.ToString();
        Console.WriteLine(" ");
        Console.WriteLine("task 14");
        Console.WriteLine(report);
    }
}
