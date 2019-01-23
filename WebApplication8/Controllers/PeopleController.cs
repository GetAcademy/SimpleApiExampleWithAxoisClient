using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Model;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DummyDbContext _context;
        private List<Person> _people;

        public PeopleController(DummyDbContext context)
        {
            _context = context;

            var per = new Person
            {
                Id = 1,
                Name = "Per",
                BirthDate = new DateTime(1980, 1, 1),
                IsMale = true
            };
            var pål = new Person
            {
                Id = 2,
                Name = "Pål",
                BirthDate = new DateTime(1950, 1, 1),
                IsMale = true
            };
            var lise = new Person
            {
                Id = 3,
                Name = "Lise",
                BirthDate = new DateTime(1950, 1, 1),
                IsMale = false
            };
            per.Father = pål;
            per.Mother = lise;
            _people = new List<Person>();
            _people.Add(per);
            _people.Add(pål);
            _people.Add(lise);
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPerson()
        {
            return _people;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<Person> GetPerson([FromRoute] int id)
        {
            var person = _people.SingleOrDefault(p=>p.Id == id);
            return person;
        }
    }
}