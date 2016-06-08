using Classroom.Interfaces;
using ClassroomFacade.Model;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Student.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClassroomFacade.Controllers
{
    public class ClassroomController : ApiController
    {
        [HttpGet]
        public async Task<string> Get(string className)
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
                ((List<Model.Student>) ClassModel.Students).Add(new Model.Student()
                { Username = await studentActor.GetUsernameAsync(), CurrentStep = await studentActor.GetCurrentStepAsync()}
                );   
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ClassModel);

        }

        [HttpGet]
        public async Task<string> Get(string className, string studentName, int newStep)
        {
            // Get the student
            var studentActor = ActorProxy.Create<IStudent>(new ActorId(studentName));
            // Update the student's steps
            await studentActor.SetCurrentStepAsync(newStep);

            return await this.Get(className);
        }

        [HttpPost]
        public void Post([FromBody]ClassroomModel value)
        {

            // Comment to trigger CI build 
            var ClassActor = ActorProxy.Create<IClassroom>(new ActorId(value.Id));

            ClassActor.SetPresenter(value.Presenter);
            ClassActor.SetNumStepsCountAsync(value.NumSteps);

            var studentCache = ClassActor.GetStudentsAsync();

            foreach (var student in value.Students)
            {
                if (!studentCache.Result.Contains(student.Username))
                {
                    ClassActor.RegisterStudentAsync(student.Username);
                }
            }
        }
    }
}

