using Clase7TareaRelaciones.Movies;
namespace Clase7TareaRelaciones.Directors;

public class Director{
    public string DirectorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int MovieId {get; set; }
    public virtual Movie Movie {get; set;}
}