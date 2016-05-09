﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Interfaces
{
    public interface IPaintingsRepository
    {
        List<Painting> GetAll();
        int Add(Painting painting);
        Painting Get(int id);
        Painting Update(Painting painting);
        bool Delete(int id);
    }
}
