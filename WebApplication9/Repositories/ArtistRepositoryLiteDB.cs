using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Interfaces;
using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class ArtistRepositoryLiteDB : IArtistRepository
    {
        private readonly string _museumConnection = @"C:\tmp\museum";

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                repository.Insert(artist);
                return artist.Id;

            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                if (repository.Update(artist))
                    return artist;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._museumConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                return repository.Delete(id);
            }
        }
    }
}