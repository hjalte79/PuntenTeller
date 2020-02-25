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
        public DbSet<PuntenTeller.Models.Cohort> Cohort { get; set; }
        public DbSet<PuntenTeller.Models.Course> Course { get; set; }
    }
}
