using Classroom.Interfaces;
using ClassroomFacade.Model;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using QueryActor.Interfaces;
using Student.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ClassroomFacade.Controllers
{
    public class ClassroomController : ApiController
    {
        [HttpGet]
        public async Task<ClassroomModel> Get(string className)
        {
            var ClassActor = ActorProxy.Create<IClassroom>(new ActorId(className));

            // Check state is initialised
            if (await ClassActor.GetNumStepsAsync() == 0)
            {
                // If doesn't exist - return 404
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            // Hydrate classroom POCO from actor async properties
            var ClassModel = new ClassroomModel();
            ClassModel.Id = className;
            ClassModel.NumSteps = await ClassActor.GetNumStepsAsync();
            ClassModel.Presenter = await ClassActor.GetPresenterAsync();
            ClassModel.Students = new List<Model.Student>();

            // Inflating the student references
            foreach (string ClassStudent in await ClassActor.GetStudentsAsync())
            {
                // Get student actor
                var studentActor = ActorProxy.Create<IStudent>(new ActorId(ClassStudent));
                
                // Create student POCO and adding to classroom students list
                Model.Student thisStudent = new Model.Student();

                thisStudent.Username = studentActor.GetActorId().ToString();
                thisStudent.CurrentStep = await studentActor.GetCurrentStepAsync();

                ClassModel.Students.Add(thisStudent);
     
            }

            return ClassModel;

        }

        [HttpGet]
        public async Task<ClassroomModel> Get(string className, string studentName, int newStep)
        {
            // Get the student
            var studentActor = ActorProxy.Create<IStudent>(new ActorId(studentName));
            // Update the student's steps
            await studentActor.SetUsernameAsync(studentName);
            await studentActor.SetCurrentStepAsync(newStep);

            // Return the main get view 
            return await this.Get(className);
        }

        [HttpGet]
        public async Task<List<string>> Get()
        {
            // Get the list of sessions
            var queryActor = ActorProxy.Create<IQueryActor>(new ActorId("ListActor"));
                    
            return await queryActor.GetClassrooms(); ;
        }

        [HttpPost]
        public void Post([FromBody]ClassroomModel value)
        {

            var ClassActor = ActorProxy.Create<IClassroom>(new ActorId(value.Id));

            // Add to the list of sessions
            var queryActor = ActorProxy.Create<IQueryActor>(new ActorId("ListActor"));
            queryActor.AddClassroom(value.Id);



            ClassActor.SetPresenter(value.Presenter);
            ClassActor.SetNumStepsCountAsync(value.NumSteps);

            var studentCache = ClassActor.GetStudentsAsync();

            foreach (var student in value.Students) 
            {
                if (!studentCache.Result.Contains(student.Username))
                {

                    var studentActor = ActorProxy.Create<IStudent>(new ActorId(student.Username));
                    studentActor.SetCurrentStepAsync(student.CurrentStep);
                    studentActor.SetUsernameAsync(student.Username);
                    ClassActor.RegisterStudentAsync(student.Username);
                }
            }

            // ClassActor.RegisterStudentAsync("Will");
            // ClassActor.RegisterStudentAsync("Jamie");
            // ClassActor.RegisterStudentAsync("Bianca");

        }
    }
}

