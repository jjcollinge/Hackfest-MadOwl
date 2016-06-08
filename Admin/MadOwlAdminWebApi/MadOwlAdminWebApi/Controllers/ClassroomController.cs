using MadOwlAdminWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MadOwlAdminWebApi.Controllers
{
    public class ClassroomController : ApiController
    {
        public Classroom GetClassroomInfo()
        {
            // HACK: hard-coded classroom
            Classroom classroom = new Classroom { Name = "Service Fabric DXNext", StepCount = 12, PinCode = 1234, ContentUri = "https://github.com/jjcollinge/MadOwl" };
            classroom.Students = new List<Student>()
            {
                new Student() {Name= "John Doe", CurrentStep = 1 },
                new Student() {Name="Jane Doe", CurrentStep = 4 },
                new Student() {Name="Benny Doe", CurrentStep = 3 }
            };

            return classroom;
        }

        public void Post([FromBody]Classroom value)
        {
            // TODO: create a new classroom
        }

    }
}
