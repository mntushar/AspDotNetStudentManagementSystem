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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required, Display(Name = "Department Name")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }


        //navigration proprty
        public virtual DepartmentModels Department { get; set; }
        public virtual StudentRegistrationModels StudentRegistration { get; set; }
    }
}