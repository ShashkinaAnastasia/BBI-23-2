
partial class Movie
{
    public static Movie[] Select(Movie[] movies, int year)
    {
        List<Movie> selectedMovies = new List<Movie>();
        foreach (var movie in movies)
        {
            if (movie.Year <= year)
                selectedMovies.Add(movie);
        }
        return selectedMovies.ToArray();
    }
}