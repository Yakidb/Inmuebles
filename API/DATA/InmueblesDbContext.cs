using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.DATA
{
    public class InmueblesDbContext : DbContext
    {
        public InmueblesDbContext() : base("name=InmueblesDB") { }

        public DbSet<inmentInmueblesEntityDB> Inmuebles { get; set; }
    }
}
