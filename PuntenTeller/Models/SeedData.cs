using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PuntenTeller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            SeedData.seedTeacher(serviceProvider);
            SeedData.seedCohort(serviceProvider);
            SeedData.seedCatogory(serviceProvider);
            SeedData.seedSubject(serviceProvider);
            SeedData.seedSchoolClass(serviceProvider);
            SeedData.seedStudent(serviceProvider);
            
        }

        private static void seedSchoolClass(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.SchoolClass.Any())
                {
                    return;   // DB has been seeded
                }
                context.SchoolClass.AddRange(
                    new SchoolClass
                    {
                        name = "1A"
                    },

                    new SchoolClass
                    {
                        name = "2B"
                    }
                );
                context.SaveChanges();
            }
        }

        private static void seedStudent(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }
                context.Student.AddRange(
                    new Student
                    {
                        id =1,
                        name = "Adam",
                        lastName = "de Jong",
                        schoolClassID = 1
                    },

                    new Student
                    {
                        id=2,
                        name = "Renske",
                        lastName = "Hagedoorn",
                        schoolClassID = 1
                    },

                    new Student
                    {
                        id=3,
                        name = "Johan",
                        lastName = "Smits",
                        schoolClassID = 1
                    }
                );
                context.SaveChanges();
            }
        }

        private static void seedSubject(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Subject.Any())
                {
                    return;   // DB has been seeded
                }
                context.Subject.AddRange(
                    new Subject
                    {
                        name = "Nederlands",
                        categoryID = 1
                    },

                    new Subject
                    {
                        name = "Duits",
                        categoryID = 2
                    },

                    new Subject
                    {
                        name = "Wiskunde",
                        categoryID = 2
                    }
                );
                context.SaveChanges();
            }
        }

        private static void seedCatogory(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.category.Any())
                {
                    return;   // DB has been seeded
                }

                context.category.AddRange(
                    new Category
                    {
                        name = "Cat1 - "
                    },

                    new Category
                    {
                        name = "Cat2 - "
                    },

                    new Category
                    {
                        name = "Cat3 - "
                    }
                );
                context.SaveChanges();
            }
        }


        private static void seedCohort(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Cohort.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cohort.AddRange(
                    new Cohort
                    {
                        name = "17/18"
                    },

                    new Cohort
                    {
                        name = "18/19"
                    },

                    new Cohort
                    {
                        name = "19/20"
                    }
                );
                context.SaveChanges();
            }

        }
        private static void seedTeacher(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Teacher.Any())
                {
                    return;   // DB has been seeded
                }

                context.Teacher.AddRange(
                    new Teacher
                    {
                        name = "Roel",
                        lastName = "Hagedoorn"
                    },

                    new Teacher
                    {
                        name = "Jelte",
                        lastName = "de Jong"
                    },

                    new Teacher
                    {
                        name = "Linda",
                        lastName = "van Mook"
                    },

                    new Teacher
                    {
                        name = "Fredi",
                        lastName = "Hagedoorn"
                    }
                );
                context.SaveChanges();
            }
        }

    } 
}
