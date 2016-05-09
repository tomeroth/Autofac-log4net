using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Contexts;
using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class ArtistRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();

            return artist.Id;
        }

        public bool Delete(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return false;
            }
            db.Artists.Remove(artist);
            db.SaveChanges();
            return true;
        }

        public Artist Get(int id)
        {
            return db.Artists.Find(id);
        }

        public List<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        public Artist Update(Artist artist)
        {
            Artist a = db.Artists.Find(artist.Id);
            if (a == null)
                return null;
            a = artist;
            db.SaveChanges();
            return artist;
        }
    }
}