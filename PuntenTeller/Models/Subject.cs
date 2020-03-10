using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Subject
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Display(Name = "Category")]
        public int categoryID { get; set; }
        public Category category { get; set; }

        public ICollection<Course> Courses { get; set; }

        //// helper properties ////
        public double getPointForStudent(int id)
        {
            double studentPoint = 0;
            int numberOfPoints = 0;
            foreach (Course course in Courses)
            {
                double point = course.getPointForStudent(id);
                if (point > 0)
                {
                    studentPoint += point;
                    numberOfPoints++;
                }

            }
            if (numberOfPoints == 0)
            {
                return 0;
            }
            return Math.Round(studentPoint / numberOfPoints, 1);
        }
    }
}
