using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomFacade.Model
{
    public class ClassroomModel
    {


        public ClassroomModel()
        { }

        public string Id { get; set; }

        public int NumSteps { get; set; }

        public string Presenter { get; set; }

        public List<Student> Students { get; set; }


    }


}
