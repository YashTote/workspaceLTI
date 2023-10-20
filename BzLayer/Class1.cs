using Entity;
using DataLayers;
namespace BzLayer;
public class MovieBz
{
 public List<Movie> GetMovies (){
    DataAccess dataAccess = new DataAccess();
    return dataAccess.GetMovies();
 }
}
