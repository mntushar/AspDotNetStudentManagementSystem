using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class CourseModels
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int SeatCount { get; set; }

        [Required]
        public int Fee { get; set; }


        //navigration proprty
        public virtual List<StudentRegistrationModels> StudentRegistration { get; set; }
    }
}