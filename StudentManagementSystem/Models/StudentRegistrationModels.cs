using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class StudentRegistrationModels
    {
        [Key, ForeignKey("Student"), Required]
        public int StudentId { get; set; }

        [ForeignKey("Course"), Required]
        public int CourseId { get; set; }

        [Display(Name ="Payment Status")]
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }


        //navigration proprty
        public virtual StudentModel Student { get; set; }
        public virtual CourseModels Course { get; set; }
        
    }
}