using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Contexts;
using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class PaintingRepository
    {
         private MuseumContext db = new MuseumContext();

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();

            return painting.Id;
        }

        public bool Delete(int id)
        {
            Painting painting = db.Paintings.Find(id);
            if (painting == null)
            {
                return false;
            }
            db.Paintings.Remove(painting);
            db.SaveChanges();
            return true;
        }

        public Painting Get(int id)
        {
            return db.Paintings.Find(id);
        }

        public List<Painting> GetAll()
        {
            return db.Paintings.ToList();
        }

        public Painting Update(Painting painting)
        {
            Painting a = db.Paintings.Find(painting.Id);
            if (a == null)
                return null;
            a = painting;
            db.SaveChanges();
            return painting;
        }
    }
}