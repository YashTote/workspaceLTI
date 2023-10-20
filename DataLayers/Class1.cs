using Entity;
namespace DataLayers;
public class DataAccess
{
 public static List<Movie> movies = new List<Movie>(){
    new Movie{Id = 1, Name = "Mi6", Ryear = 2021, Ratings = 8},
    new Movie{Id = 2, Name = "Fifty shades", Ryear = 2016, Ratings = 10},
    new Movie{Id = 3, Name = "Swashank Redemption", Ryear = 1999, Ratings = 9},
    new Movie{Id = 4, Name = "Barbie", Ryear = 2023, Ratings = 5},
    new Movie{Id = 5, Name = "Oppenhiemer", Ryear = 2023, Ratings = 9}
 };
 public List<Movie> GetMovies(){
    return movies;
 }


}
