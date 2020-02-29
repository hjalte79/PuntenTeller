using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Course
    {
        public int id { get; set; }

        public string name { get; set; }

        [Display(Name = "Teacher")]
        public int teacherID { get; set; }
        public Teacher teacher { get; set; }

        [Display(Name = "Cohort")]
        public int cohortID { get; set; }
        public Cohort cohort { get; set; }

        [Display(Name = "Subject")]
        public int subjectID { get; set; }
        public Subject subject { get; set; }

        public int period { get; set; }

    }
}
