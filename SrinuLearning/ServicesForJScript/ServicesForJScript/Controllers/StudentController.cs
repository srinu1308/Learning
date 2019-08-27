using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ServicesForJScript.Business;
using ServicesForJScript.Repository;
using System.Web.Http.Cors;

namespace ServicesForJScript.Controllers
{
    public class StudentController : ApiController
    {
        [EnableCors(origins: "http://localhost:8062", headers: "*", methods: "*")]
        [HttpGet]
        public Students GetStudents()
        {
            StudentRepository repo = new StudentRepository();

            return repo.GetStudents();

        } 
    }
}
