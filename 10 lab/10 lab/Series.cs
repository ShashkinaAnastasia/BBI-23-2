using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Series : Movie
{
    [XmlIgnore]
    public int[,] SeriesAmount { get; set; }

    [XmlElement]
    public override double Length {
        get { return TotalLength(); }
        set { }
    }

    [XmlArray]
    [JsonIgnore]
    public int[][] seriesAmount { 
        get {
            var myJaggedArray = new int[SeriesAmount.GetLength(0)][];
            for (int i = 0; i < SeriesAmount.GetLength(0); i++)
            {
                myJaggedArray[i] = new int[SeriesAmount.GetLength(1)];
                for (int j = 0; j < SeriesAmount.GetLength(1); j++)
                    myJaggedArray[i][j] = SeriesAmount[i, j];
            }
            return myJaggedArray;
        }
        set {
            SeriesAmount = new int[value.GetLength(0), value[0].GetLength(0)];
            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value[i].GetLength(0); j++)
                    SeriesAmount[i, j] = value[i][j];
            }
        }
    }

    public int TotalLength()
    {
        int totalLength = 0;
        for (int seasonIndex = 0; seasonIndex < SeriesAmount.GetLength(0); ++seasonIndex)
        {
            for (int seriesIndex = 0; seriesIndex < SeriesAmount.GetLength(1); ++seriesIndex)
            {
                totalLength += SeriesAmount[seasonIndex, seriesIndex];
            }
        }
        return totalLength;
    }

    [JsonConstructor]
    public Series(string Title, string Director, int Year, double Rating, int[,] SeriesAmount)
        : base(Title, Director, Year, Rating, 0)
    {
        this.SeriesAmount = SeriesAmount;
    }

    public Series() : 
        base() 
    {
        SeriesAmount = new int[0,0];
    }

    public override string ToString()
    {
        return base.ToString() + $", Total Length: {TotalLength()}";
    }
}
