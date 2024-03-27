using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

abstract class Survey
{
    public string animal { get; }
    public string character { get; }
    public string thing { get; }

    public Survey(string _animal, string _character, string _thing)
    {
        animal = _animal;
        character = _character;
        thing = _thing;
    }

    public abstract void printSurvey();
}

class SurveyWithCountry : Survey
{
    public string country { get; }

    public SurveyWithCountry(string _animal, string _character, string _thing, string _country)
        : base(_animal, _character, _thing)
    {
        country = _country;
    }

    public override void printSurvey() 
    {
        Console.WriteLine(
            "Country: {0, 6} | Animal: {1,15} | char: {2,20} | thing: {3,15}",
            country, animal, character, thing);
    }
}

class RussianSurvey : SurveyWithCountry
{
    public RussianSurvey(string _animal, string _character, string _thing)
        : base(_animal, _character, _thing, "Russia")
    {
    }
}


class JapanSurvey : SurveyWithCountry
{
    public JapanSurvey(string _animal, string _character, string _thing)
        : base(_animal, _character, _thing, "Japan")
    {
    }
}

class Program
{
    static void printElemCountOfArray(KeyValuePair<string, int>[] values, int limit, int totalCount)
    {
        Console.WriteLine();
        for (int index = 0; index < Math.Min(limit, values.Length); ++index)
        {
            Console.WriteLine(
                "value: {0,20} | percent: {1,6}%",
                values[index].Key, ((double)values[index].Value / totalCount * 100).ToString("00.00" +
                "" +
                ""));
        }
    }

    static void CalculatePercentsByCountry(Survey[] survery)
    {
        for (int index = 0; index < survery.Length; ++index)
            survery[index].printSurvey();

        int animalAnswers = survery.Count(surveyItem => !string.IsNullOrEmpty(surveyItem.animal));
        int charAnswers = survery.Count(surveyItem => !string.IsNullOrEmpty(surveyItem.character));
        int thingAnswers = survery.Count(surveyItem => !string.IsNullOrEmpty(surveyItem.thing));

        Dictionary<string, int> animalAnswersCount = new Dictionary<string, int>();
        for (int index = 0; index < survery.Length; ++index)
        {
            if (animalAnswersCount.ContainsKey(survery[index].animal))
                animalAnswersCount[survery[index].animal]++;
            else
                animalAnswersCount[survery[index].animal] = 1;
        }
        var animalAnswersAsArray = animalAnswersCount.ToArray();
        Array.Sort(animalAnswersAsArray, (a, b) => a.Value.CompareTo(b.Value));
        Array.Reverse(animalAnswersAsArray);
        printElemCountOfArray(animalAnswersAsArray, 5, animalAnswers);

        Dictionary<string, int> charAnswersCount = new Dictionary<string, int>();
        for (int index = 0; index < survery.Length; ++index)
        {
            if (charAnswersCount.ContainsKey(survery[index].character))
                charAnswersCount[survery[index].character]++;
            else
                charAnswersCount[survery[index].character] = 1;
        }
        var charAnswersAsArray = charAnswersCount.ToArray();
        Array.Sort(charAnswersAsArray, (a, b) => a.Value.CompareTo(b.Value));
        Array.Reverse(charAnswersAsArray);
        printElemCountOfArray(charAnswersAsArray, 5, charAnswers);


        Dictionary<string, int> thingAnswersCount = new Dictionary<string, int>();
        for (int index = 0; index < survery.Length; ++index)
        {
            if (thingAnswersCount.ContainsKey(survery[index].thing))
                thingAnswersCount[survery[index].thing]++;
            else
                thingAnswersCount[survery[index].thing] = 1;
        }
        var thingAnswersAsArray = thingAnswersCount.ToArray();
        Array.Sort(thingAnswersAsArray, (a, b) => a.Value.CompareTo(b.Value));
        Array.Reverse(thingAnswersAsArray);
        printElemCountOfArray(thingAnswersAsArray, 5, thingAnswers);
    }

    static void Main()
    {
        Survey[] japanSurvery = { 
            new JapanSurvey("кошка", "застенчивость", "рис"),
            new JapanSurvey("собака", "дисциплинированость", "кимоно"),
            new JapanSurvey("рыба", "вежливость", "сакура"),
            new JapanSurvey("дракон", "целеустремлённость", "сакура"),
            new JapanSurvey("дракон", "скромность", "рис")
        };

        Survey[] russainSurvery = {
            new RussianSurvey("медведь", "трудолюбие", "чай"),
            new RussianSurvey("медведь", "вежливость", "гречка")
        };

        Console.WriteLine();
        Console.WriteLine("==== Japan ====");
        CalculatePercentsByCountry(japanSurvery);

        Console.WriteLine();
        Console.WriteLine("==== Russia ====");
        CalculatePercentsByCountry(russainSurvery);

        Survey[] total = new Survey[japanSurvery.Length + russainSurvery.Length];
        russainSurvery.CopyTo(total, 0);
        japanSurvery.CopyTo(total, russainSurvery.Length);

        Console.WriteLine();
        Console.WriteLine("==== total ====");
        CalculatePercentsByCountry(total);
    }
}

