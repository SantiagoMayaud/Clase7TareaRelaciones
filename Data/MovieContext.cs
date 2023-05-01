using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clase7TareaRelaciones.Movies;

namespace Clase7TareaRelaciones.data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Clase7TareaRelaciones.Movies.Movie> Movie { get; set; } = default!;
        public DbSet<Clase7TareaRelaciones.Actors.Actor> Actors { get; set; } = default!;
        public DbSet<Clase7TareaRelaciones.Directors.Director> Directors { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder){ 
            modelBuilder.Entity<Movie>()
            .HasMany(p=> p.Actors)
            .WithOne(p=> p.Director)
            .HasForeignKey(p => p.ActorId);
        }
    }
}
