using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication9.Models;

namespace WebApplication9.Contexts
{
    public class MuseumContext : DbContext
    {
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}