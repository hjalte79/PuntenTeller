using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Course
    {
        public int id { get; set; }

        [Required]
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

        [Required]
        [Range(1, 52)]
        public int period { get; set; }

        ///// navigation properties /////
        // known by
        public ICollection<Exam> exams { get; set; }


        //// helper properties ////
        public double getPointForStudent(int id)
        {
            if (exams == null) return 0;

            double studentPoint = 0;
            int numberOfPoints = 0;
            foreach (Exam exam in exams)
            {
                double point = exam.getPointForStudent(id);
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
