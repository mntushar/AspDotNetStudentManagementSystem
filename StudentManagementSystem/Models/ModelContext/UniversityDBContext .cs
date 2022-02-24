using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Data.Entity;

namespace StudentManagementSystem.Models.ModelContext
{
    public class UniversityDBContext : DbContext
    {
        public DbSet<DepartmentModels> Department { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<CourseModels> Course { get; set; }
        public DbSet<StudentRegistrationModels> StudentRegistration { get; set; }
    }
}