using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Exam
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        ///// navigation properties /////
        // knows
        [Display(Name = "Course")]
        public int courseID { get; set; }
        public Course course { get; set; }

        // known by
        public ICollection<Point> points { get; set; }

        //// helper properties ////
        public double getPointForStudent(int id)
        {
            if (points == null) return 0;
            double studentPoint = 0;
            foreach (Point point in points)
            {
                if (point.student == null) continue;
                if (point.student.id == id)
                {
                    if (point.value > studentPoint)
                    {
                        studentPoint = point.value;
                    }
                }
            }
            return studentPoint;
        }
    }
}
