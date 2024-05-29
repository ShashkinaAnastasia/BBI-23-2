using System.Text.Json.Serialization;
using System.Xml.Serialization;

[XmlInclude(typeof(Series))]
[XmlInclude(typeof(Cartoon))]
[Serializable]
public partial class Movie
{
    private string _title;
    private string _director;
    private int _year;
    private double _rating;
    private double _length;

    [XmlElement]
    public string Title { 
        get { return _title; }
        set { _title = value; }
    }

    [XmlElement]
    public string Director { 
        get { return _director; }
        set { _director = value; }
    }

    [XmlElement]
    public int Year { 
        get { return _year; }
        set { _year = value; }
    }

    [XmlElement]
    public double Rating { 
        get { return _rating; } 
        set { _rating = value; }
    }

    [XmlElement]
    public virtual double Length { 
        get { return _length; } 
        set { _length = value; }
    }

    [JsonConstructor]
    public Movie(string Title, string Director, int Year, double Rating, double Length)
    {
        _title = Title;
        _director = Director;
        _year = Year;
        _rating = Rating;
        _length = Length;
    }

    public Movie()
    {
        _title = "";
        _director = "";
    }

    public override string ToString()
    {
        return $"Title: {Title}, Director: {Director}, Year: {Year}, Rating: {Rating}, Length: {Length}";
    }
}