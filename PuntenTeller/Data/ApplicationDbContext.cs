using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PuntenTeller.Models;

namespace PuntenTeller.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Cohort> Cohort { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
