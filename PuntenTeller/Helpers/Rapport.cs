using Microsoft.EntityFrameworkCore;
using PuntenTeller.Data;
using PuntenTeller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Helpers
{
    public class Rapport
    {
        private readonly ApplicationDbContext _context;

        public Rapport(ApplicationDbContext context)
        {
            _context = context;

            numberOfPeriods = 4;
        }
        public Student student { get; set; }
        public IOrderedEnumerable<Course> courses { get; set; }
        public List<Category> categories { get; set; }
        public int numberOfPeriods { get; set; }

        public async Task getData(int studentId)
        {
            student = await _context.Student
                .Include(s => s.schoolClass)
                .Include(s => s.schoolClass.classCourses)
                .FirstOrDefaultAsync(m => m.id == studentId);

            if (student == null)
            {
                throw new Exception("Could not find student.");
            }

            List<Course> allCourses = new List<Course>();
            foreach (ClassCourse classCourse in student.schoolClass.classCourses)
            {

                var course = await _context.Course
                    .Include(s => s.exams)
                    .Include(s => s.subject)
                        .ThenInclude(s => s.category)
                    .FirstOrDefaultAsync(m => m.id == classCourse.courseID);
                allCourses.Add(course);
            }
            courses = allCourses
                .OrderBy(c => c.subject.category.name)
                .ThenBy(c => c.subject.name)
                .ThenBy(c => c.period);


            foreach (Course course in courses)
            {
                foreach (Exam exam in course.exams)
                {
                    _context.Entry(exam).Collection(p => p.points).Load();

                }
            }

            categories = new List<Category>();
            foreach (Course course in courses)
            {
                if (categories.Contains(course.subject.category) == false)
                {
                    categories.Add(course.subject.category);
                }
            }

            foreach (Category category in categories)
            {
                foreach (Subject subject in category.subjects)
                {
                    for (int i = 1; i <= numberOfPeriods; i++)
                    {
                        var test = i;
                        var cc = subject.Courses.Where(c => c.period == i).ToList();
                        if (cc.Count() == 0)
                        {
                            subject.Courses.Add(new Course()
                            {
                                period = i
                            });
                        }
                        

                    }
                    subject.Courses = subject.Courses.OrderBy(c => c.period).ToList();
                }
            }

        }
        


    }
}
