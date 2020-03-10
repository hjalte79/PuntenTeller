using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }

        ///// navigation properties /////
        // knows
        [Display(Name = "Class")]
        public int schoolClassID { get; set; }
        public SchoolClass schoolClass { get; set; }

        // known by
        public ICollection<Point> points { get; set; }

        public string fullName
        {
            get
            {
                return $"{name} {lastName}";
            }
        }
    }
}
