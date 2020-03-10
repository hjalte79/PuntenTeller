using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class SchoolClass
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        ///// navigation properties /////
        // known by
        public ICollection<Student> students { get; set; }
        public ICollection<ClassCourse> classCourses { get; set; }
    }
}
