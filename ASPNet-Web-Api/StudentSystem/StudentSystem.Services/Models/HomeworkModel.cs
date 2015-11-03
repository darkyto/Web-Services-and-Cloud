using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Services.Models
{
    public class HomeworkModel
    {
        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        [ForeignKey("Student")]
        public int StudentIdentification { get; set; }

        public virtual StudentModel Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual CourseModel Course { get; set; }
    }
}