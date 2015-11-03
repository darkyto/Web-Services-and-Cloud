namespace StudentSystem.Services.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 
    public class StudentModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public virtual StudentModel Assistant { get; set; }

        [InverseProperty("Assistant")]
        public virtual ICollection<StudentModel> Trainees { get; set; }

        public virtual ICollection<CourseModel> Courses { get; set; }

        public virtual ICollection<HomeworkModel> Homeworks { get; set; }

        public StudentInfoModel AdditionalInformation { get; set; }
    }
}