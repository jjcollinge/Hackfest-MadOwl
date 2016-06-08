using ClassroomFacade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClassroomFacade.Controllers
{
    public class ClassroomController : ApiController
    {
        public string GetClassroomInfo(string classroomName)
        {
            //// HACK: hard-coded classroom
            //Classroom classroom = new Classroom { Name = "Service Fabric DXNext", StepCount = 12, PinCode = 1234, ContentUri = "https://github.com/jjcollinge/MadOwl" };
            //classroom.Students = new List<Student>()
            //{
            //    new Student() {Name= "John Doe", CurrentStep = 1 },
            //    new Student() {Name="Jane Doe", CurrentStep = 4 },
            //    new Student() {Name="Benny Doe", CurrentStep = 3 }
            //};

            //return classroom;

            var thisClassroom = new Classroom();

            return thisClassroom.ToString();
        }

        public void Post([FromBody]Classroom value)
        {
            // TODO: create a new classroom
        }

    }
}

