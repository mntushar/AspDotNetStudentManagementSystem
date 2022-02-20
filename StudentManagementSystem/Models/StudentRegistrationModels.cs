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
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }


        //navigration proprty
        public virtual StudentModel Student { get; set; }
        public virtual CourseModels Course { get; set; }
        
    }
}