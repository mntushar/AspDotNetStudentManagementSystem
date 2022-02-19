using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.ModelContext
{
    public class UniversityDBContext : DbContext
    {
        public DbSet<DepartmentModels> Department { get; set; }
        public DbSet<StudentModel> Student { get; set; }
    }
}