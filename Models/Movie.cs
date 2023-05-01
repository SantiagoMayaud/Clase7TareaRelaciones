using Clase7TareaRelaciones.Actors;
using Clase7TareaRelaciones.Directors;
namespace Clase7TareaRelaciones.Movies;

public class Movie 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DirectorId {get; set; }
    public List<Actor> Actors {get; } = new List<Actor>();
}