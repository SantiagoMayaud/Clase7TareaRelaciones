using Clase7TareaRelaciones.Movies;
namespace Clase7TareaRelaciones.Actors;

public class Actor {
    public string ActorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Movie> Movies {get; } = new List<Movie>();
}