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
