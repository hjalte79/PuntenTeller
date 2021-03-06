﻿using System;
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
        public DbSet<Student> Student { get; set; }
        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<ClassCourse> ClassCourse { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Point> Point { get; set; }
    }
}
