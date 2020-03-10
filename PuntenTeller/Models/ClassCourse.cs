using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class ClassCourse
    {
        public int id { get; set; }

        ///// navigation properties /////
        // knows
        [Display(Name = "Class")]
        public int schoolClassID { get; set; }
        public SchoolClass schoolClass { get; set; }

        [Display(Name = "Course")]
        public int courseID { get; set; }
        public Course course { get; set; }

    }
}
