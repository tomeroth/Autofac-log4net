using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Contexts;
using WebApplication9.Models;

namespace WebApplication9.Initializers
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            List<Artist> seedArtists = new List<Artist>();
            seedArtists.Add(new Artist { ArtistName = "Pablo", ArtistSurname = "Picasso" });
            seedArtists.Add(new Artist { ArtistName = "Leonardo", ArtistSurname = "Da Vinci" });
            seedArtists.Add(new Artist { ArtistName = "Jan", ArtistSurname = "Matejko" });
            seedArtists.Add(new Artist { ArtistName = "Sandro", ArtistSurname = "Botticelli" });
            seedArtists.Add(new Artist { ArtistName = "Michał", ArtistSurname = "Anioł" });
            foreach (Artist a in seedArtists) context.Artists.Add(a);

            context.SaveChanges();

            List<Painting> seedPaintings = new List<Painting>();

            seedPaintings.Add(new Painting() { Title = "Mona Lisa", Year = 1503 });
            seedPaintings.Add(new Painting() { Title = "Grunwald", Year = 1878 });
            seedPaintings.Add(new Painting() { Title = "Guernica", Year = 1937 });
            seedPaintings.Add(new Painting() { Title = "Narodziny Wenus", Year = 1478 });
            seedPaintings.Add(new Painting() { Title = "Stworzenie Adama", Year = 1511 });
            foreach (Painting b in seedPaintings) context.Paintings.Add(b);

            context.SaveChanges();
        }
    }
}