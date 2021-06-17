using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace School.API.Controllers
{
    [EnableCors("https://localhost:44309", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet()]
        public List<Student> GetAllStudent()
        {
            loaddata();
            return Students;
        }

        private void loaddata()
        {
            Students = new List<Student>();
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Saroj Karki" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Saroj Shreestha" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Himanshu Tiwari" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Anchal Lama" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Guddi Sharma" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Nirajan Kushwaha" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Amit Yadav" });
            Students.Add(new Student { Id = Guid.NewGuid(), Name = "Chandan Bhagat" });
        }

        private static List<Student> Students = new List<Student>();
    }

    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}