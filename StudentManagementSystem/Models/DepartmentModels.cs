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

        [Required, Display(Name = "Department Name")]
        public string DeptName { get; set; }


        //navigration proprty
        public virtual List<StudentModel> Students { get; set; }
    }
}