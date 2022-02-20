using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual DepartmentModels Department { get; set; }
    }
}