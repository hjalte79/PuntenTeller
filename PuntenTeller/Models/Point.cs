using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Point
    {
        public int id { get; set; }

        [Required]
        [Range(1, 100)]
        public double value { get; set; }
        [Required]
        public int resit { get; set; }

        ///// navigation properties /////
        // knows
        [Display(Name = "Student")]
        public int studentID { get; set; }
        public Student student { get; set; }

        [Display(Name = "Exam")]
        public int examID { get; set; }
        public Exam exam { get; set; }
    }
}
