using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Model;

namespace WebApplication8.Models
{
    public class DummyDbContext : DbContext
    {
        public DummyDbContext (DbContextOptions<DummyDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication8.Model.Person> Person { get; set; }
    }
}
