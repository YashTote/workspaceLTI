// See https://aka.ms/new-console-template for more information
using System;
using Entity;
using BzLayer;
// using Data

// Console.WriteLine("Hello, World!");
MovieBz bz = new MovieBz();
List<Movie> movies = bz.GetMovies();
if(movies != null)
{
    foreach(var m in movies)
    {
        Console.WriteLine($"{m.Id} {m.Name} {m.Ratings} {m.Ryear}");
    }}
    else Console.WriteLine("No Moives Present");
