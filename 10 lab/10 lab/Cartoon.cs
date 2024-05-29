using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Cartoon : Movie
{
    private string _ageRating;
    private string _style;

    [XmlElement]
    public string AgeRating { 
        get { return _ageRating; }
        set { _ageRating = value; }
    }

    [XmlElement]
    public string Style { 
        get { return _style; }
        set { _style = value; }
    }

    [JsonConstructor]
    public Cartoon(string title, string director, int year, double rating, double length, string AgeRating, string Style)
       : base(title, director, year, rating, length)
    {
        _ageRating = AgeRating;
        _style = Style;
    }

    public Cartoon() : base()
    {
        _ageRating = "";
        _style = "";
    }

    public override string ToString()
    {
        return $"Title: {Title}, Director: {Director}, Year: {Year}, Rating: {Rating}, Length: {Length} mins, Age Rating: {AgeRating}, Style: {Style}";
    }
}

