using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Course
    {
        public int id { get; set; }

        public string name { get; set; }
        public Teacher teacher { get; set; }
        public Cohort cohort { get; set; }
        public int period { get; set; }

    }
}
