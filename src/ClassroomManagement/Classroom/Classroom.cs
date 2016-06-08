using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using Classroom.Interfaces;

namespace Classroom
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class Classroom : Actor, IClassroom
    {

        public async Task<int> GetNumStepsAsync()
        {
            return await this.StateManager.GetStateAsync<int>("NumSteps");
        }

        public async Task<string> GetPresenter()
        {
            return await this.StateManager.GetStateAsync<string>("Presenter");
        }

        public async Task<IList<string>> GetStudents()
        {
            return await this.StateManager.GetStateAsync<IList<string>>("Students");
        }

        public async Task RegisterStudent(string student)
        {

            var tempStudents = await this.StateManager.TryGetStateAsync<IList<string>>("Students");

            if (tempStudents.HasValue)
            {

                tempStudents.Value.Add(student);

                await this.StateManager.SetStateAsync<IList<string>>("Students", tempStudents.Value);
            }
            else
            {
                var otherTempStudents = new List<string>();

                otherTempStudents.Add(student);

                await this.StateManager.SetStateAsync<IList<string>>("Students", otherTempStudents);

            }
        }

        public async Task SetNumStepsCountAsync(int numSteps)
        {

            await this.StateManager.SetStateAsync<int>("NumSteps",numSteps);
                        
        }

        public async Task SetPresenter(string presenter)
        {
            await this.StateManager.SetStateAsync<string>("Presenter", presenter);
        }

        public async Task SetStudents(IList<string> students)
        {

            await this.StateManager.SetStateAsync<IList<string>>("Students", students);


        }
        
        
        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            // The StateManager is this actor's private state store.
            // Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            // Any serializable object can be saved in the StateManager.
            // For more information, see http://aka.ms/servicefabricactorsstateserialization


            return this.StateManager.TryAddStateAsync("count", 0);

        }
        
 
    }
}
