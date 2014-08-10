using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Sparkles.GenericRestService.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        { }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Objects> Objects { get; set; }
    }
}