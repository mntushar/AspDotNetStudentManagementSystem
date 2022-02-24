using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace StudentManagementSystem.Models.ModelContext
{
    public class UniversityDBContext : DbContext
    {
        public DbSet<DepartmentModels> Department { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<CourseModels> Course { get; set; }
        public  DbSet<StudentRegistrationModels> StudentRegistration { get; set; }
    }
}