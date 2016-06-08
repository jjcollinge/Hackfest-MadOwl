using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomFacade.Model
{
    public class Classroom
    {
        public string Id { get; set; }

        public int NumSteps { get; set; }

        public string Presenter { get; set; }

        public IEnumerable<string> Students { get; set; }
    }
}
