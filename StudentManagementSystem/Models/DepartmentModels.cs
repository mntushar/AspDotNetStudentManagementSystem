using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class DepartmentModels
    {
        public int Id { get; set; }

        [Required]
        public string DeptName { get; set; }
        public virtual List<StudentModel> Students { get; set; }
    }
}