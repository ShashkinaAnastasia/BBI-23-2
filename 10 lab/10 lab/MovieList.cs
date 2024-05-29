using System.Text.Json.Serialization;
using System.Xml.Serialization;

interface IMoviesList
{
    public void AddMovie(Movie movie);
    public void RemoveMovie(Movie movie);
    public void AddMovie(Movie[] movies);
    public void RemoveMovie(int index);
    public void DisplayList();
}

[Serializable]
public class MoviesList : IMoviesList
{
    [XmlArray]
    public List<Movie> movies { get; }

    bool MovieAlreadyAdded(Movie movie)
    {
        foreach (Movie nextMovie in movies)
        {
            if (movie == nextMovie)
                return true;
        }
        return false;
    }

    public void AddMovie(Movie movie)
    {
        if (!MovieAlreadyAdded(movie))
            movies.Add(movie);
    }

    public void RemoveMovie(Movie movie)
    {
        movies.Remove(movie);
    }

    public void AddMovie(Movie[] movies)
    {
        foreach (Movie movie in movies)
            AddMovie(movie);
    }

    public void RemoveMovie(int index)
    {
        movies.RemoveAt(index);
    }

    public void DisplayList()
    {
        foreach (Movie movie in movies)
            Console.WriteLine(movie.ToString());
    }

    public Movie[] getMovies()
    {
        List<Movie> result = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.GetType() == typeof(Movie))
                result.Add(movie);
        }
        return result.ToArray();
    }

    public Movie[] getSeries()
    {
        List<Movie> result = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.GetType() == typeof(Series))
                result.Add(movie);
        }
        return result.ToArray();
    }
    public Movie[] getAllMoviesOfCatalog()
    {
        return movies.ToArray();
    }

    public int Count()
    {
        return movies.Count;
    }

    public void SortByDate()
    {
        Movie.SortDate(movies);
    }
    public void SortByTitle()
    {
        Movie.SortTitle(movies);
    }

    public MoviesList()
    {
        this.movies = new List<Movie>();
    }

    [JsonConstructor]
    public MoviesList(List<Movie> movies)
    {
        this.movies = movies;
    }
}
