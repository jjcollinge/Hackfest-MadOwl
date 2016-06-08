using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadOwlAdminWebApi.Models
{
    public class Classroom
    {
        public string Name { get; set; }
        public int StepCount { get; set; }
        public int PinCode { get; set; }
        public string ContentUri { get; set; }
        public List<Student> Students { get; set; }
    }
}