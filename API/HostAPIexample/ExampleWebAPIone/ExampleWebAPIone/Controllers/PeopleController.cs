using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExampleWebAPIone.Models;

namespace ExampleWebAPIone.Controllers
{
    public class PeopleController : ApiController
    {
        /// <summary>
        /// to replace database in this format for examples
        /// </summary>
        List<Person> people = new List<Person>();
        public PeopleController()
        {
            people.Add(new Person { FirstName = "jonny", SecondName = "watson", Id = 1 });
            people.Add(new Person { FirstName = "dave", SecondName = "dallis", Id = 2 });
            people.Add(new Person { FirstName = "sue", SecondName = "davies", Id = 3 });
        }


        // GET: api/People
        [Route("api/listAllPeople")]
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/int
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).First();
        }
        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
