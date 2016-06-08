using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Classroom.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IClassroom : IActor
    {
        Task<int> GetNumStepsAsync();
        Task SetNumStepsCountAsync(int numSteps);
        
        Task<string> GetPresenterAsync();
        Task SetPresenter(string presenter);

        Task<IList<string>> GetStudentsAsync();
        Task SetStudents(IList<string> students);

        Task RegisterStudentAsync(string student);

    }
}
