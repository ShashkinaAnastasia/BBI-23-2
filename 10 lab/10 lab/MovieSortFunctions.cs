using System;
using System.Collections.Generic;

partial class Movie
{
    public static void SortTitle(List<Movie> movies)
    {
        int i = 0, j = 1;
        while (j < movies.Count - 1)
        {
            if (i < 0 || String.Compare(movies[i].Title, movies[i + 1].Title) <= 0)
            {
                i = j;
                j++;
            }
            while (i >= 0 && String.Compare(movies[i].Title, movies[i + 1].Title) > 0)
            {
                Movie temp = movies[i];
                movies[i] = movies[i + 1];
                movies[i + 1] = temp;
                i--;
            }
        }
    }

    public static void SortDate(List<Movie> movies)
    {
        int i = 0, j = 1;
        while (j < movies.Count - 1)
        {
            if (i < 0 || movies[i].Year <= movies[i + 1].Year)
            {
                i = j;
                j++;
            }
            while (i >= 0 && movies[i].Year > movies[i + 1].Year)
            {
                Movie temp = movies[i];
                movies[i] = movies[i + 1];
                movies[i + 1] = temp;
                i--;
            }
        }
    }
}
